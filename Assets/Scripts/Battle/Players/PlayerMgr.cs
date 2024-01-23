using Battle.Arrivals;
using Battle.Tricks;
using Common;
using Foundation;
using System.Collections.Generic;
using UnityEngine;
using World;

namespace Battle.Players
{
    public interface IPlayerView : IModelView<Player>
    {
        void notify_on_tick1();
    }


    public class PlayerMgr : ChessMgr, IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<VID ,Player> m_cells = new();

        //==================================================================================================

        public PlayerMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);

            var wctx = WorldContext.instance;
            wctx.remove_tick(m_mgr_name);
            wctx.remove_tick1(m_mgr_name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            var wctx = WorldContext.instance;
            wctx.add_tick(m_mgr_priority, m_mgr_name, tick);
            wctx.add_tick1(m_mgr_priority, m_mgr_name, tick1);
        }


        void tick()
        {
            
        }


        void tick1()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick1();
            }
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            cell = default;

            var pos = (VID)args[0];
            if (!m_cells.TryGetValue(pos, out var _cell)) return false;

            cell = _cell;
            return true;
        }


        public void add_cell(Player cell)
        {
            m_cells.Add(cell.pos, cell);
        }


        public void remove_cell(VID pos)
        {
            m_cells.Remove(pos);
        }


        public override void move(ref VID pos, Vector2 step)
        {
            if (!m_cells.TryGetValue(pos, out var cell)) return;

            var from = pos;
            opti_move(ref pos, step);

            remove_cell(from);
            add_cell(cell);
        }


        public override bool try_get_arrivals(VID pos, out VID[] arrival_pos_array)
        {
            arrival_pos_array = default;
            if (!m_cells.TryGetValue(pos, out var cell)) return false;

            //规则：根据配置读取可达范围
            EX_Utility.try_load_asset(("arrivals", "Arrival_Asset_Test"), out Arrival_Asset asset);
            arrival_pos_array = VID.convert(asset.pos_array, pos);

            return true;
        }
    }
}

