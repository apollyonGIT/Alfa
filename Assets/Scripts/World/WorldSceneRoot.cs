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
            ctx.init();

            init_producers();

            ctx.can_start_tick = true;
        }


        protected override void on_fini()
        {
            fini_producers();
        }


        private void Update()
        {
            ctx.update();
        }


        public void btn_enter_battle()
        {
            ui_active(false);

            Battle_In_Out_Helper.instance.enter_battle(ctx);
        }


        public void btn_end_battle()
        {
            Battle_In_Out_Helper.instance.end_battle(ctx);

            ui_active(true);
        }


        void ui_active(bool bl)
        {
            uiRoot.gameObject.SetActive(bl);
            monoRoot.gameObject.SetActive(bl);
        }
    }
}

