using Common.Opr_Module;
using Foundation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class SceneRoot<T> : MonoBehaviourSingleton<T> where T : SceneRoot<T>
    {
        public Camera mainCamera;
        public Camera uiCamera;
        public Canvas uiRoot;
        public Transform monoRoot;

        public Producer[] producers;

        //==================================================================================================

        protected void init_producers()
        {
            if (producers == null) return;

            foreach (var t in producers)
            {
                t.init();
            }
        }


        protected void fini_producers()
        {
            if (producers == null) return;

            foreach (var t in producers)
            {
                t.fini();
            }
        }


        protected void oprSender_click_event(PointerEventData eventData)
        {
            var pos = uiCamera.ScreenToWorldPoint(eventData.position);
            pos += mainCamera.transform.position;
            pos.z = 0;

            var hit = Physics2D.Raycast(pos, Vector2.zero).transform;
            if (hit == null) return;
            if (!hit.TryGetComponent(out OprReciver reciver)) return;

            reciver.target.notify_on_click();
        }
    }
}

