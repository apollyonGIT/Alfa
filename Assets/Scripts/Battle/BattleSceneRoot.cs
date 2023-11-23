using Common;
using World;

namespace Battle
{
    public class BattleSceneRoot : SceneRoot<BattleSceneRoot>
    {
        WorldContext ctx;
        WorldSceneRoot root;

        //==================================================================================================

        protected override void on_init()
        {
            root = WorldSceneRoot.instance;
            uiCamera = WorldSceneRoot.instance.uiCamera;
            uiRoot.worldCamera = uiCamera;

            ctx = WorldContext.instance;
        }


        public void btn_vectory()
        {
            root.btn_end_battle();
        }


        public void btn_fail()
        {
            root.btn_end_battle();
        }
    }
}

