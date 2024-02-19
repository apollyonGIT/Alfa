using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Common.Opr_Module
{
    public class OprSender : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PointerEventData> click_event;
        public event Action<float> scroll_event;

        //==================================================================================================

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            click_event(eventData);
        }


        private void Update()
        {
            var scroll = Mouse.current.scroll.y.ReadValue();
            if (scroll != 0)
            {
                scroll = scroll > 0 ? 1 : -1;
                scroll_event(scroll);
            }
        }
    }
}

