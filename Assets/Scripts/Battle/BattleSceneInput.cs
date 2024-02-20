using Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviour
    {
        bool m_is_right_mouse_hold;

        Vector3 m_ori_camera_pos;
        Vector3 m_ori_mouse_pos;

        //==================================================================================================

        public void OnLeftMouseClick()
        {
            Battle_Mouse_Helper.instance.calc_mouse_pos(out var pos);

            var hit = Physics2D.Raycast(pos, Vector2.zero).transform;
            if (hit == null)
            {
                Mission.instance.try_get_mgr("InteractiveMgr", out var interactive_mgr);
                interactive_mgr.GetType().GetMethod("notify_on_left_click_null")?.Invoke(interactive_mgr, null);
                return;
            }

            if (!hit.TryGetComponent(out InputView view)) return;

            var mgr = view.iv_mgr;
            mgr.GetType().GetMethod("notify_on_left_click")?.Invoke(mgr, new object[] { view.iv_cell });
        }


        public void OnZoomIn()
        {
            Battle_Camera_Helper.instance.change_size(-1);
        }


        public void OnZoomOut()
        {
            Battle_Camera_Helper.instance.change_size(1);
        }


        public void OnRightMouseDown()
        {
            m_is_right_mouse_hold = true;

            m_ori_camera_pos = BattleSceneRoot.instance.mainCamera.transform.localPosition;
            m_ori_mouse_pos = (Vector3)Mouse_Helper.calc_mouse_pos(BattleSceneRoot.instance.uiCamera);
        }


        public void OnRightMouseUp()
        {
            m_is_right_mouse_hold = false;
        }


        public void OnRightMouseDrag()
        {
            if (!m_is_right_mouse_hold) return;

            BattleSceneRoot.instance.mainCamera.transform.localPosition = m_ori_camera_pos + (m_ori_mouse_pos - (Vector3)Mouse_Helper.calc_mouse_pos(BattleSceneRoot.instance.uiCamera));
        }
    }
}

