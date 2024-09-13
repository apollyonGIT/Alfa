using Foundation;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Common;
using System.Collections.Generic;

namespace Battle.HandCards
{
    public class HandCardView : MonoBehaviour, IHandCardView, IDragHandler, IBeginDragHandler, IEndDragHandler
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


        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            Common_DS.instance.add("card_ori_pos", transform.position);
        }


        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            var can_use = !EX_Utility.valid_in_ui(eventData, "handcard_area");

            //打出
            if (can_use)
            {
                cell.use();
            }
            else //放回手牌栏
            {
                Common_DS.instance.try_get_value("card_ori_pos", out Vector3 pos);
                transform.position = pos;
            }
        }
    }
}

