using Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviour
    {
        bool m_is_right_mouse_hold;
        Vector3 m_temp_pos;

        BattleContext ctx;
        BattleSceneRoot root;

        //==================================================================================================

        public void on_init()
        {
            ctx = BattleContext.instance;
            root = BattleSceneRoot.instance;
        }


        public void OnLeftMouseClick()
        {
            Battle_Mouse_Helper.instance.calc_mouse_pos(out var pos);

            EX_Utility.raycast(pos, notify_on_left_click_null,
                (view) =>
                {
                    var mgr = view.vmgr;
                    mgr.GetType().GetMethod("notify_on_left_click")?.Invoke(mgr, new object[] { ctx, view.vcell });
                }
            );
        }


        public void notify_on_left_click_null()
        {
        }


        public void OnZoomIn()
        {
            Battle_Camera_Helper.instance.change_size(-0.5f);
        }


        public void OnZoomOut()
        {
            Battle_Camera_Helper.instance.change_size(0.5f);
        }


        public void OnRightMouseDown()
        {
            if (root.valid_in_ui(out _)) return;

            m_is_right_mouse_hold = true;
            m_temp_pos = Battle_Camera_Helper.instance.pos + (Vector3)Mouse_Helper.calc_mouse_pos(BattleSceneRoot.instance.uiCamera);
        }


        public void OnRightMouseUp()
        {
            m_is_right_mouse_hold = false;
        }


        public void OnRightMouseDrag()
        {
            if (!m_is_right_mouse_hold) return;

            var pos = m_temp_pos - (Vector3)Mouse_Helper.calc_mouse_pos(BattleSceneRoot.instance.uiCamera);
            Battle_Camera_Helper.instance.move_to_pos(pos);
        }


        public void OnMoveUp()
        {
            player_move(Vector2.up);
        }


        public void OnMoveDown()
        {
            player_move(Vector2.down);
        }


        public void OnMoveLeft()
        {
            player_move(Vector2.left);
        }


        public void OnMoveRight()
        {
            player_move(Vector2.right);
        }


        void player_move(Vector2 dir)
        {
            Mission.instance.try_get_mgr("PlayerMgr", out Players.PlayerMgr mgr);
            mgr.move_by_step(ctx, dir);

            root.next_turn();
            clean();
        }


        public void OnWait()
        {
            root.next_turn();
        }


        public void OnFly()
        {
            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr mgr);

            if (ctx.player_status == EN_player_status.none)
            {
                foreach (var pos in ctx.fly_pos_array)
                {
                    mgr.set_cell_color(pos, Config.current.fly_area_color);
                }

                ctx.player_status = EN_player_status.show_fly_area;
                return;
            }

            mgr.clear_cells_color();
            ctx.player_status = EN_player_status.none;
        }


        void clean()
        {
            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr mgr);
            mgr.clear_cells_color();
        }


        public void btn_test()
        {
            Mission.instance.try_get_mgr("EnemyMgr", out Enemys.EnemyMgr enemy_mgr);
            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr land_mgr);

            var start = enemy_mgr.temp_cell_pos_for_test;
            var end = Vector2.zero;

            var obstacles = new LinkedList<Vector2>();
            obstacles.AddLast(new Vector2(1, 0));

            foreach (var pos in obstacles)
            {
                land_mgr.set_cell_color(pos, Color.red);
            }

            if (!Common.SeekPath_Module.SeekPath_Utility.try_seek_path(start, end, obstacles.ToArray(), VID.valid_in_area, out var paths))
                return;

            foreach (var pos in paths)
            {
                land_mgr.set_cell_color(pos, Color.gray);
            }
        }
    }
}

