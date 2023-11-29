using Battle.Helpers;
using Common;
using Foundation;
using System.Collections.Generic;
using System.Linq;
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

        Dictionary<int, Chess> m_cells = new();

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

        }


        void tick1()
        {
            foreach (var (_, cell) in m_cells)
            {
                foreach (var view in cell.views)
                {
                    view.notify_on_tick1();
                }
            }
        }


        public void add_cell(Chess cell)
        {
            m_cells.Add(cell.vid, cell);
        }


        /// <summary>
        /// 移动
        /// </summary>
        public void move(Chess cell, int step_x, int step_y)
        {
            var key = cell.vid;            
            SquareMap_Helper.move(ref cell.vid, step_x, step_y);

            if (cell.vid != key)
            {
                m_cells.Remove(key);
                m_cells.Add(cell.vid, cell);
            }
        }


        /// <summary>
        /// 创建攻击范围
        /// </summary>
        public void create_attack_area()
        { 
            
        }
    }
}

