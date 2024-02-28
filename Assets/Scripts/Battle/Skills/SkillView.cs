using Common;
using Foundation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battle.Skills
{
    public class SkillView : View, ISkillView, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector]
        public SkillPD pd;
        Skill cell;

        int m_index;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Skill>.attach(Skill cell)
        {
            this.cell = cell;
        }


        void IModelView<Skill>.detach(Skill cell)
        {
            this.cell = null;
        }


        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (cell.mgr.is_casting) return;

            transform.localPosition = new(transform.localPosition.x, pd.selected_height_offset);
            transform.localScale = Vector3.one * pd.selected_scale_offset;

            m_index = transform.GetSiblingIndex();
            pd.standing.SetSiblingIndex(m_index);
            pd.standing.gameObject.SetActive(true);

            transform.SetParent(pd.selecting_area);
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
            transform.localPosition = new(transform.localPosition.x, 0);
            transform.localScale = Vector3.one;

            transform.SetParent(pd.transform);

            transform.SetSiblingIndex(m_index);
            pd.standing.gameObject.SetActive(false);
            pd.standing.SetAsLastSibling();
        }
    }
}

