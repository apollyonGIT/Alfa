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


        void IMgr.init(object[] args)
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


        public void notify_on_left_click(Interactive cell)
        {
            var pos = cell.pos;

            var bctx = BattleContext.instance;
            var mission = Mission.instance;
            {
                if (!mission.try_get_mgr("PlayerMgr", out Players.PlayerMgr player_mgr)) return;
                if (!mission.try_get_mgr("ArrivalMgr", out Arrivals.ArrivalMgr arrival_mgr)) return;
                if (!mission.try_get_mgr("SkillMgr", out Skills.SkillMgr skill_mgr)) return;
                if (!mission.try_get_mgr("EnemyMgr", out Enemys.EnemyMgr enemy_mgr)) return;

                bool is_player = (player_mgr as IMgr).try_get_cell(out _, pos);
                bool is_arrival = (arrival_mgr as IMgr).try_get_cell(out _, pos, true);
                bool is_enemy = (enemy_mgr as IMgr).try_get_cell(out var enemy, pos);

                //规则：未选中player，且目标为player，则高亮其移动/攻击范围
                if (is_player && !is_arrival)
                {
                    player_mgr.try_get_arrivals(pos, out var arrival_array);
                    arrival_mgr.active_cell(arrival_array);
                    bctx.foucs_pos = pos;
                    return;
                }

                //规则：已选中player，且目标非player，则player移动/攻击
                if (is_arrival && !is_player)
                {
                    if (is_enemy)
                    {
                        player_mgr.current_player_prop("dmg", out var dmg);
                        enemy.GetType().GetMethod("hurt")?.Invoke(enemy, new object[] { dmg });
                    }
                    else
                        player_mgr.move_to(pos);

                    reset();
                    return;
                }

                //默认：
                reset();
            }
        }


        public void notify_on_left_click_null()
        {
            reset();
        }


        /// <summary>
        /// 复位，清空所有选中状态
        /// </summary>
        void reset()
        {
            var bctx = BattleContext.instance;
            var mission = Mission.instance;
            {
                if (!mission.try_get_mgr("ArrivalMgr", out Arrivals.ArrivalMgr arrival_mgr)) return;

                arrival_mgr.unactive_cells();
                bctx.foucs_pos = null;
            }
        }
    }
}

