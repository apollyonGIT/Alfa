using Common;
using UnityEngine;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviour
    {
        bool m_is_right_mouse_hold;
        Vector3 m_temp_pos;

        //==================================================================================================

        public void OnLeftMouseClick()
        {
            Battle_Mouse_Helper.instance.calc_mouse_pos(out var pos);

            EX_Utility.raycast(pos, notify_on_left_click_null,
                (view) =>
                {
                    var mgr = view.vmgr;
                    mgr.GetType().GetMethod("notify_on_left_click")?.Invoke(mgr, new object[] { view.vcell });
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
            if (BattleSceneRoot.instance.valid_in_ui(out _)) return;

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
            mgr.move_by_step(dir);

            BattleSceneRoot.instance.next_turn();
            clean();
        }


        public void OnWait()
        {
            BattleSceneRoot.instance.next_turn();
        }


        public void OnFly()
        {
            Mission.instance.try_get_mgr("PlayerMgr", out Players.PlayerMgr mgr);
            mgr.show_fly_area();
        }


        void clean()
        {
            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr mgr);
            mgr.clear_cells_color();
        }
    }
}

