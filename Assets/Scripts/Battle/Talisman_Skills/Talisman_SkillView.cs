using Foundation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battle.Talisman_Skills
{
    public class Talisman_SkillView : MonoBehaviour, ITalisman_SkillView, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public Transform node;

        [HideInInspector]
        public Talisman_SkillPD pd;
        Talisman_Skill cell;

        int m_index;
        bool m_is_dragging;

        //==================================================================================================

        void IModelView<Talisman_Skill>.attach(Talisman_Skill cell)
        {
            this.cell = cell;
        }


        void IModelView<Talisman_Skill>.detach(Talisman_Skill cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }


        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            transform.localPosition = new(transform.localPosition.x, pd.selected_height_offset);
            transform.localScale = Vector3.one * pd.selected_scale_offset;

            m_index = transform.GetSiblingIndex();
            pd.standing.SetSiblingIndex(m_index);
            pd.standing.gameObject.SetActive(true);

            transform.SetParent(pd.selecting_area);
        }


        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (m_is_dragging) return;
            reset();
        }


        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;

            Cursor.SetCursor(pd.cursor, Vector2.zero, CursorMode.Auto);
            m_is_dragging = true;
        }


        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;

            reset();
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            m_is_dragging = false;
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

