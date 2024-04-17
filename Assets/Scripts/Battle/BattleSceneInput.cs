using Common;
using Foundation;
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

    }
}

