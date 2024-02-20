using Common;
using UnityEngine;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviour
    {
        public void OnSelect()
        {
            Mouse_Helper.calc_mouse_pos(BattleSceneRoot.instance.mainCamera, out var pos);

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
            Camera_Helper.instance.change_size(-1);
        }


        public void OnZoom_out()
        {
            Camera_Helper.instance.change_size(1);
        }
    }
}

