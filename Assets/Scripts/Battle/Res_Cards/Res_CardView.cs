using Foundation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using World;

namespace Battle.Res_Cards
{
    public class Res_CardView : MonoBehaviour, IRes_CardView, IPointerEnterHandler, IPointerExitHandler
    {
        public Transform node;

        [HideInInspector]
        public Res_CardPD pd;
        Res_Card cell;

        int m_index;

        //==================================================================================================

        void IModelView<Res_Card>.attach(Res_Card cell)
        {
            this.cell = cell;
        }


        void IModelView<Res_Card>.detach(Res_Card cell)
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

            transform.SetParent(pd.res_area);

            transform.SetSiblingIndex(m_index);
            pd.standing.gameObject.SetActive(false);
            pd.standing.SetAsLastSibling();
        }
    }
}

