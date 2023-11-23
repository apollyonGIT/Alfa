using Common;
using World;

namespace Battle
{
    public class BattleSceneRoot : SceneRoot<BattleSceneRoot>
    {
        WorldSceneRoot root;

        //==================================================================================================

        //0
        protected override void on_init()
        {
            root = WorldSceneRoot.instance;
            mainCamera = root.mainCamera;
            uiCamera = root.uiCamera;
            uiRoot.worldCamera = uiCamera;
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

