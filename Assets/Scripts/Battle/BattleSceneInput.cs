using Common;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviourSingleton<BattleSceneInput>
    {
        BattleContext ctx;
        BattleSceneRoot root;

        //==================================================================================================

        protected override void on_init()
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


        public void OnRightMouseClick()
        {
            Debug.Log(111);
        }


        public void OnMoveUp()
        {
            AC_Move.player_move_by_step(ctx, Vector2.up);
        }


        public void OnMoveDown()
        {
            AC_Move.player_move_by_step(ctx, Vector2.down);
        }


        public void OnMoveLeft()
        {
            AC_Move.player_move_by_step(ctx, Vector2.left);
        }


        public void OnMoveRight()
        {
            AC_Move.player_move_by_step(ctx, Vector2.right);
        }


        public void OnWait()
        {
            root.next_turn();
        }


        public void OnShowFlyArea()
        {
            AC_Fly.show_fly_area(ctx);
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

