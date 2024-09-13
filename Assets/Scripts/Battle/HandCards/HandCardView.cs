using Foundation;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace Battle.HandCards
{
    public class HandCardView : MonoBehaviour, IHandCardView, IDragHandler
    {
        public TextMeshProUGUI title;

        HandCard cell;
        RectTransform rect;

        //==================================================================================================


        void IModelView<HandCard>.attach(HandCard cell)
        {
            this.cell = cell;
            rect = GetComponent<RectTransform>();

            fresh();
        }


        void IModelView<HandCard>.detach(HandCard cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }


        public void fresh()
        {
            title.text = $"{cell._desc.f_name}";
        }


        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            transform.position = Battle_Mouse_Helper.instance.calc_mouse_pos_ui(eventData, rect);
        }
    }
}

