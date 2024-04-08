using Common;
using Common.Ticker_Module;
using Foundation;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Players
{
    public interface IPlayerView : IModelView<Player>
    {
        void notify_on_tick1();
    }


    public class PlayerMgr : IMgr, IEntityMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        IEnumerable<VID> IEntityMgr.pos_array => EX_Utility.convert_obj_to_ienum(cell.pos);

        public Player cell;

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

            var ticker = Ticker.instance;
            {
                ticker.remove_tick(m_mgr_name);
                ticker.remove_tick1(m_mgr_name);
            }
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            var ticker = Ticker.instance;
            {
                ticker.add_tick(m_mgr_priority, m_mgr_name, tick);
                ticker.add_tick1(m_mgr_priority, m_mgr_name, tick1);
            }
        }


        void tick()
        {
        }


        void tick1()
        {
            cell.tick1();
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            cell = this.cell;
            return true;
        }


        public void move_to_pos(Vector2 new_pos)
        {
            Entity_Helper.move_to_pos(ref cell.pos, new_pos);
        }


        public void move_by_step(Vector2 step)
        {
            Entity_Helper.move_by_step(ref cell.pos, step);
        }


        /// <summary>
        /// 左键触发
        /// </summary>
        public void notify_on_left_click(Player cell)
        {
        }


        public void show_fly_area()
        {
            var ctx = BattleContext.instance;
            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr land_mgr);
            
            if (ctx.player_status == EN_player_status.none)
            {
                foreach (var pos in cell.arrival_pos_array)
                {
                    land_mgr.set_cell_color(pos, Config.current.fly_area_color);
                    land_mgr.enable_cell_color(pos, true);
                }

                ctx.player_status = EN_player_status.show_fly_area;
                return;
            }

            land_mgr.clear_cells_color();
            ctx.player_status = EN_player_status.none;
        }
    }
}

