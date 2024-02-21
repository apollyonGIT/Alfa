using Foundation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using World;

namespace Battle.Talisman_Skills
{
    public class Talisman_SkillView : MonoBehaviour, ITalisman_SkillView, IPointerEnterHandler, IPointerExitHandler
    {
        public Transform node;

        [HideInInspector]
        public Talisman_SkillPD pd;
        Talisman_Skill cell;

        int m_index;

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
            transform.localPosition = new(transform.localPosition.x, 0);
            transform.localScale = Vector3.one;

            transform.SetParent(pd.transform);

            transform.SetSiblingIndex(m_index);
            pd.standing.gameObject.SetActive(false);
            pd.standing.SetAsLastSibling();
        }
    }
}

