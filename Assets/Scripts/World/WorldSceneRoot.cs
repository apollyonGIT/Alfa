using Common;

namespace World
{
    public class WorldSceneRoot : SceneRoot<WorldSceneRoot>
    {
        WorldContext ctx;

        //==================================================================================================

        protected override void on_init()
        {
            ctx = WorldContext._init();

            init_producers();
        }


        protected override void on_fini()
        {
            fini_producers();
        }


        public void btn_in_battle()
        {
            ui_active(false);

            Battle_In_Out_Helper.instance.in_battle(ctx);
        }


        public void btn_out_battle()
        {
            Battle_In_Out_Helper.instance.out_battle(ctx);

            ui_active(true);
        }


        void ui_active(bool bl)
        {
            uiRoot.gameObject.SetActive(bl);
            monoRoot.gameObject.SetActive(bl);
        }
    }
}

