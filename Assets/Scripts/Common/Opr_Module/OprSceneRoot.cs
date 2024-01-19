using UnityEngine.EventSystems;
using UnityEngine;

namespace Common.Opr_Module
{
    public class OprSceneRoot<T> : SceneRoot<OprSceneRoot<T>>
    {
        public OprSender oprSender;

        //==================================================================================================

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


        protected override void on_init()
        {
            oprSender.click_event += oprSender_click_event;
        }
    }
}

