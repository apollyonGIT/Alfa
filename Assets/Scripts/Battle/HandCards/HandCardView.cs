using Foundation;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Common.Helpers;
using World;

namespace Battle.HandCards
{
    public class HandCardView : MonoBehaviour, IHandCardView, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public TextMeshProUGUI title;

        HandCard cell;
        Mouse_Move_Helper helper;

        //==================================================================================================

        void IModelView<HandCard>.attach(HandCard cell)
        {
            this.cell = cell;
            title.text = cell._desc.f_name;

            helper = Mouse_Move_Helper.instance;
            helper.init(WorldSceneRoot.instance.uiCamera);
        }


        void IModelView<HandCard>.detach(HandCard cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }


        void IModelView<HandCard>.shift(HandCard old_cell, HandCard new_cell)
        {
        }


        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            helper.calc_offset(transform.position);
        }


        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            transform.position = helper.drag_pos;
        }


        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            helper.fini();

            cell.mgr.play(cell);
        }


        void IHandCardView.notify_on_reset_pos()
        {
            transform.localPosition = cell.view_init_pos;
        }
    }
}

