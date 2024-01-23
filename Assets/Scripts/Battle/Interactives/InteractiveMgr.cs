using Common;
using Foundation;
using System.Collections.Generic;

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

            var bctx = BattleContext.instance;
            var mission = Mission.instance;
            {
                if (!mission.try_get_mgr("PlayerMgr", out var player_mgr)) return;
                if (!mission.try_get_mgr("ArrivalMgr", out var arrival_mgr)) return;

                bool is_player = player_mgr.try_get_cell(out _, pos);
                bool is_arrival = arrival_mgr.try_get_cell(out _, pos, true);

                //规则：如果选中player，且不位于可达高亮，则高亮其可达范围
                if (is_player && !is_arrival)
                {
                    var try_get_arrivals_args = new object[] { pos, null };
                    player_mgr.GetType().GetMethod("try_get_arrivals").Invoke(player_mgr, try_get_arrivals_args);
                    var arrival_array = try_get_arrivals_args[1];
                    arrival_mgr.GetType().GetMethod("active_cell")?.Invoke(arrival_mgr, new object[] { arrival_array });

                    bctx.foucs_pos = pos;
                    return;
                }

                //规则：如果选中player，且位于可达高亮，则无事发生
                if (is_player && is_arrival) return;

                //规则：如果位于可达高亮，且非player，则player移动
                if (is_arrival && !is_player)
                {
                    player_mgr.GetType().GetMethod("move_to").Invoke(player_mgr, new object[] { pos });
                    arrival_mgr.GetType().GetMethod("unactive_cells")?.Invoke(arrival_mgr, null);
                    
                    bctx.foucs_pos = null;
                    return;
                }

                //默认：
                {
                    arrival_mgr.GetType().GetMethod("unactive_cells")?.Invoke(arrival_mgr, null);

                    bctx.foucs_pos = null;
                }
                
            }
        }
    }
}

