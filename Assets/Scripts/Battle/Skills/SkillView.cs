using Common;
using Foundation;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Battle.Skills
{
    public class SkillView : View, ISkillView, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public TextMeshProUGUI title;
        public TextMeshProUGUI content;

        public GameObject cost;
        public TextMeshProUGUI cost_value;

        public RawImage bg;

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
            if (!cell.is_active || cell.is_lock) return;
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
            if (!cell.is_active || cell.is_lock) return;
            if (cell.mgr.is_casting) return;

            reset();
        }


        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (!cell.is_active || cell.is_lock) return;
            if (eventData.button != PointerEventData.InputButton.Left) return;

            Cursor.SetCursor(pd.cursor, Vector2.zero, CursorMode.Auto);
            cell.mgr.is_casting = true;
        }


        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (!cell.is_active || cell.is_lock) return;
            if (eventData.button != PointerEventData.InputButton.Left) return;

            reset();
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            cell.mgr.is_casting = false;

            cell.cast();
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


        void ISkillView.notify_on_tick1()
        {
            if (!cell.is_active)
            {
                bg.color = Color.gray;
                return;
            }

            title.text = cell.title;
            content.text = cell.content;

            cost_value.text = $"{cell.cost}";
            cost.SetActive(title.text.Any());
        }
    }
}

