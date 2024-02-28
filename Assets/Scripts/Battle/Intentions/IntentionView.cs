using Foundation;
using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battle.Intentions
{
    public class IntentionView : View, IIntentionView, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector]
        public IntentionPD pd;
        Intention cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Intention>.attach(Intention cell)
        {
            this.cell = cell;
        }


        void IModelView<Intention>.detach(Intention cell)
        {
            this.cell = null;
        }


        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (!cell.is_opr_access) return;
            if (cell.mgr.is_casting) return;

            transform.localScale = Vector3.one * pd.selected_scale_offset;
        }


        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (!cell.is_opr_access) return;
            if (cell.mgr.is_casting) return;

            reset();
        }


        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (!cell.is_opr_access) return;
            if (eventData.button != PointerEventData.InputButton.Left) return;

            Cursor.SetCursor(pd.cursor, Vector2.zero, CursorMode.Auto);
            cell.mgr.is_casting = true;
        }


        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (!cell.is_opr_access) return;
            if (eventData.button != PointerEventData.InputButton.Left) return;

            reset();
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            cell.mgr.is_casting = false;
        }


        void @reset()
        {
            transform.localScale = Vector3.one;
        }


        void IIntentionView.notify_on_tick1()
        {
            gameObject.SetActive(cell.is_active);
        }
    }
}

