using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Opr_Module
{
    public class OprSender : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PointerEventData> click_event;

        //==================================================================================================

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            click_event(eventData);
        }
    }
}

