using Common;
using Common.Opr_Module;
using UnityEngine;
using World;

namespace Battle
{
    public class BattleSceneRoot : OprSceneRoot<BattleSceneRoot>
    {
        WorldSceneRoot root;
        BattleContext bctx;

        //==================================================================================================

        protected override void on_init()
        {
            root = WorldSceneRoot.instance;
            mainCamera = root.mainCamera;
            uiCamera = root.uiCamera;
            uiRoot.worldCamera = uiCamera;

            init_producers();

            base.on_init();

            bctx = BattleContext.instance;
        }


        protected override void on_fini()
        {
            fini_producers();
        }


        public void btn_vectory()
        {
            root.btn_out_battle();
        }


        public void btn_fail()
        {
            root.btn_out_battle();
        }


        public void move_main_camera(Vector2 move_to)
        {
            var pos = mainCamera.transform.localPosition;
            pos = new Vector3(move_to.x, move_to.y, pos.z);
            mainCamera.transform.localPosition = pos;
        }


        public void btn_next()
        {
            Battle_Next_Turn_Helper.instance.next_turn(bctx);
        }


        public override void notify_on_click_null()
        {
            Mission.instance.try_get_mgr("InteractiveMgr", out var interactive_mgr);
            interactive_mgr.GetType().GetMethod("do_on_click_null")?.Invoke(interactive_mgr, null);
        }
    }
}

