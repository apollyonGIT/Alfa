using Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviour
    {
        public void OnSelect()
        {
            var root = BattleSceneRoot.instance;
            var pos = root.uiCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            pos += root.mainCamera.transform.position;
            pos.z = 0;

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


        public void OnZoom_in()
        {
            Camera_Helper.change_camera_projection_size(-1);
        }


        public void OnZoom_out()
        {
            Camera_Helper.change_camera_projection_size(1);
        }
    }
}

