using Common;
using UnityEngine;
using UnityEngine.EventSystems;
using World;

namespace Battle
{
    public class BattleSceneRoot : SceneRoot<BattleSceneRoot>
    {
        WorldSceneRoot root;

        //==================================================================================================

        protected override void on_init()
        {
            root = WorldSceneRoot.instance;
            mainCamera = root.mainCamera;
            uiCamera = root.uiCamera;
            uiRoot.worldCamera = uiCamera;

            init_producers();
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


        public bool try_get_mouse_attach_cpn(PointerEventData eventData, out OprReciver reciver)
        {
            var pos = uiCamera.ScreenToWorldPoint(eventData.position);
            pos += mainCamera.transform.position;
            pos.z = 0;

            var hit = Physics2D.Raycast(pos, Vector2.zero);

            return hit.transform.TryGetComponent(out reciver);
        }
    }
}

