using Common;
using UnityEngine;

namespace Battle
{
    public class Battle_Mouse_Helper : Mouse_Helper<Battle_Mouse_Helper>
    {
        public override Camera camera => BattleSceneRoot.instance.mainCamera;

        //==================================================================================================

        public static void do_hit_view_method<T>(string method_name) where T : InteractiveView
        {
            instance.calc_mouse_pos(out var pos);

            var hit = Physics2D.Raycast(pos, Vector2.zero).transform;
            if (hit == null) return;
            if (!hit.TryGetComponent(out T iview)) return;

            var view = iview.target;
            if (view != null)
                view.GetType().GetMethod(method_name)?.Invoke(view, null);
        }
    }
}

