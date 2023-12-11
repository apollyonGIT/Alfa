using Common;
using Foundation;
using System.Collections.Generic;
using UnityEngine;
using World;

namespace Battle.Chesses
{
    public interface IChessView : IModelView<Chess>
    {
        void notify_on_tick1();
    }


    public class ChessMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<VID, Chess> m_cells = new();

        //==================================================================================================

        public ChessMgr(string name, params object[] objs)
        {
            m_mgr_name = name;
            (this as IMgr).init(objs);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);

            var ctx = WorldContext.instance;
            ctx.remove_tick(Config.ChessMgr_Player_Name);
            ctx.remove_tick1(Config.ChessMgr_Player_Name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            var ctx = WorldContext.instance;
            ctx.add_tick(Config.ChessMgr_Player_Priority, Config.ChessMgr_Player_Name, tick);
            ctx.add_tick1(Config.ChessMgr_Player_Priority, Config.ChessMgr_Player_Name, tick1);
        }


        void tick()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick();
            }
        }


        void tick1()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick1();
            }
        }


        public void add_cell(Chess cell)
        {
            m_cells.Add(cell.vid, cell);
        }


        public void move(VID vid, int step_x, int step_y)
        {
            if (!m_cells.TryGetValue(vid, out var cell)) return;
            m_cells.Remove(vid);

            VID.move(ref cell.vid, step_x, step_y);
            add_cell(cell);
        }


        bool IMgr.try_get_cell(out object cell, params object[] prms)
        {
            var vid = (VID)prms[0];
            var ret = m_cells.TryGetValue(vid, out var _cell);
            cell = _cell;

            return ret;
        }
    }
}

