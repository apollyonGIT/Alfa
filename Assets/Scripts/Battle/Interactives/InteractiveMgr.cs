﻿using Common;
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


        public void do_on_click(Interactive cell)
        {
            var pos = cell.pos;

            var bctx = BattleContext.instance;
            var mission = Mission.instance;
            {
                if (!mission.try_get_mgr("PlayerMgr", out Players.PlayerMgr player_mgr)) return;
                if (!mission.try_get_mgr("ArrivalMgr", out Arrivals.ArrivalMgr arrival_mgr)) return;
                if (!mission.try_get_mgr("Res_CardMgr", out Res_Cards.Res_CardMgr res_card_mgr)) return;
                if (!mission.try_get_mgr("EnemyMgr", out Enemys.EnemyMgr enemy_mgr)) return;

                bool is_player = (player_mgr as IMgr).try_get_cell(out _, pos);
                bool is_arrival = (arrival_mgr as IMgr).try_get_cell(out _, pos, true);
                bool is_enemy = (enemy_mgr as IMgr).try_get_cell(out var enemy, pos);

                //规则：如果选中player，且不位于可达高亮，则高亮其可达范围
                if (is_player && !is_arrival)
                {
                    player_mgr.try_get_arrivals(pos, out var arrival_array);
                    arrival_mgr.active_cell(arrival_array);
                    bctx.foucs_pos = pos;
                    return;
                }

                //规则：如果选中自身，且位于可达高亮，则无事发生
                if (is_player && pos == (VID)bctx.foucs_pos && is_arrival) return;

                //规则：如果位于可达高亮，且非player，则player移动/攻击
                if (is_arrival && !is_player)
                {
                    if (is_enemy)
                    {
                        player_mgr.current_player_prop("dmg", out var dmg);
                        enemy.GetType().GetMethod("hurt")?.Invoke(enemy, new object[] { dmg });
                    }
                    else
                        player_mgr.move_to(pos);

                    res_card_mgr.play();

                    arrival_mgr.unactive_cells();
                    bctx.foucs_pos = null;
                    return;
                }

                //默认：
                {
                    arrival_mgr.unactive_cells();
                    bctx.foucs_pos = null;
                    return;
                }
            }
        }


        public void do_on_click_null()
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

