using Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using World;

namespace Battle
{
    public class BattleSceneRoot : SceneRoot<BattleSceneRoot>
    {
        GraphicRaycaster m_gr;
        PointerEventData m_pointer_event;
        List<RaycastResult> m_ray_results = new();

        WorldSceneRoot root;

        //==================================================================================================

        protected override void on_init()
        {
            root = WorldSceneRoot.instance;
            mainCamera = root.mainCamera;
            uiCamera = root.uiCamera;
            uiRoot.worldCamera = uiCamera;
            m_gr = uiRoot.GetComponent<GraphicRaycaster>();

            init_producers();

            m_pointer_event = new(EventSystem.current);
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
            call_producers();
        }


        public bool valid_in_ui(out List<RaycastResult> result)
        {
            m_ray_results.Clear();
            m_pointer_event.position = Mouse.current.position.ReadValue();
            m_gr.Raycast((m_pointer_event), m_ray_results);
            result = m_ray_results;
            return m_ray_results.Any();
        }
    }
}

