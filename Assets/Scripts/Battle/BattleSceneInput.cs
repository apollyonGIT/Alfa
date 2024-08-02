using Common;
using UnityEngine;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviour
    {
        public void OnLeftMouseClick()
        {
            Battle_Mouse_Helper.instance.calc_mouse_pos(out var pos);

            var hit = Physics2D.Raycast(pos, Vector2.zero).transform;
            if (hit == null) return;
            if (!hit.TryGetComponent(out InteractiveView iview)) return;

            var view = iview.target;
            if (view != null)
                view.GetType().GetMethod("notify_on_left_click")?.Invoke(view, null);
        }


        public void OnRightMouseClick()
        {
        }
    }
}

