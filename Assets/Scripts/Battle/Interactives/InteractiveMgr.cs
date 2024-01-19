using Common;
using Foundation;
using System.Collections.Generic;
using UnityEngine.Video;

namespace Battle.Interactives
{
    public interface IInteractiveView : IModelView<Interactive>
    {
    }


    public class InteractiveMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<VID, Interactive> m_cells = new();

        //==================================================================================================

        public InteractiveMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            throw new System.NotImplementedException();
        }


        public void add_cell(Interactive cell)
        {
            m_cells.Add(cell.pos, cell);
        }


        public void do_on_click(Interactive cell)
        {
            var pos = cell.pos;

            var mission = Mission.instance;
            {
                //尝试选中player
                if (!mission.try_get_mgr("PlayerMgr", out var player_mgr)) return;

                //获取可达范围
                var try_get_arrivals_args = new object[] { pos, null };
                if (!(bool)player_mgr.GetType().GetMethod("try_get_arrivals").Invoke(player_mgr, try_get_arrivals_args)) return;
                var arrival_array = try_get_arrivals_args[1];

                //高亮可达范围
                if (!mission.try_get_mgr("ArrivalMgr", out var arrival_mgr)) return;
                arrival_mgr.GetType().GetMethod("active_cell")?.Invoke(arrival_mgr, new object[] { arrival_array });

            }



        }
    }
}

