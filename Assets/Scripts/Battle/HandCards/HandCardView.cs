using Foundation;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Common.Helpers;
using World;
using Common;

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

            transform.localPosition = cell.view_pos;
            cell.view_pos = transform.position;
        }


        void IModelView<HandCard>.detach(HandCard cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }


        void IModelView<HandCard>.shift(HandCard old_cell, HandCard new_cell)
        {
        }


        void IHandCardView.notify_on_tick1()
        {
            transform.position = cell.view_pos;
        }


        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            helper.calc_offset(cell.view_pos);
        }


        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            helper.fini();

            //Mission.instance.try_get_mgr(Config.HandCardMgr_Name, out HandCardMgr mgr);
            //mgr.play(cell);
        }


        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            cell.view_pos = helper.drag_pos;
        }
    }
}

