using Common;
using UnityEngine;
using UnityEngine.InputSystem;
using World;

namespace Battle
{
    public class BattleSceneRoot : SceneRoot<BattleSceneRoot>
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


        public void btn_next()
        {
            Battle_Next_Turn_Helper.instance.next_turn(bctx);
        }
    }
}

