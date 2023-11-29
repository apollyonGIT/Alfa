using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Opr_Module
{
    public class OprSender : MonoBehaviour, IPointerClickHandler
    {
        public delegate void Click_Handle(PointerEventData eventData);
        public event Click_Handle click_event;

        //==================================================================================================

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            click_event(eventData);
        }
    }
}

