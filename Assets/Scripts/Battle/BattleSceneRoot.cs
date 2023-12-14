using Common.Opr_Module;
using World;

namespace Battle
{
    public class BattleSceneRoot : OprSceneRoot<BattleSceneRoot>
    {
        public OprSender oprSender;

        WorldSceneRoot root;

        //==================================================================================================

        protected override void on_init()
        {
            root = WorldSceneRoot.instance;
            mainCamera = root.mainCamera;
            uiCamera = root.uiCamera;
            uiRoot.worldCamera = uiCamera;

            init_producers();

            oprSender.click_event += oprSender_click_event;
        }


        protected override void on_fini()
        {
            fini_producers();
        }


        public void btn_vectory()
        {
            root.btn_end_battle();
        }


        public void btn_fail()
        {
            root.btn_end_battle();
        }


        public void btn_next_turn()
        {
            tick_producers();
        }
    }
}

