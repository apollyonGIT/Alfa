using Foundation;
using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battle.Miracles
{
    public class MiracleView : View, IMiracleView, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector]
        public MiraclePD pd;
        Miracle cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Miracle>.attach(Miracle cell)
        {
            this.cell = cell;
        }


        void IModelView<Miracle>.detach(Miracle cell)
        {
            this.cell = null;
        }


        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (cell.mgr.is_casting) return;

            transform.localScale = Vector3.one * pd.selected_scale_offset;
        }


        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (cell.mgr.is_casting) return;

            reset();
        }


        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;

            Cursor.SetCursor(pd.cursor, Vector2.zero, CursorMode.Auto);
            cell.mgr.is_casting = true;
        }


        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;

            reset();
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            cell.mgr.is_casting = false;
        }


        void @reset()
        {
            transform.localScale = Vector3.one;
        }
    }
}

