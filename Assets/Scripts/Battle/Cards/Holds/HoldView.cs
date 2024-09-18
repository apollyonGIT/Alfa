using Foundation;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Common;

namespace Battle.Cards
{
    public class HoldView : MonoBehaviour, IHoldView, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public TextMeshProUGUI title;

        Hold cell;
        RectTransform rect;

        //==================================================================================================


        void IModelView<Hold>.attach(Hold cell)
        {
            this.cell = cell;
            rect = GetComponent<RectTransform>();

            fresh();
        }


        void IModelView<Hold>.detach(Hold cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }


        public void fresh()
        {
            title.text = $"{cell.card._desc.f_name}";
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
            var can_use = !EX_Utility.valid_in_ui(eventData, "hold_area");

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

