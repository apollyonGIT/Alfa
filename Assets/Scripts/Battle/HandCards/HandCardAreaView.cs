using Foundation;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace Battle.HandCards
{
    public class HandCardAreaView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        //==================================================================================================

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            BattleContext.instance.is_in_handcard_area = true;
        }


        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            BattleContext.instance.is_in_handcard_area = false;
        }
    }
}

