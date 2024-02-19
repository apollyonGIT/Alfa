using Foundation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battle.Res_Cards
{
    public class Res_CardView : MonoBehaviour, IRes_CardView, IPointerEnterHandler, IPointerExitHandler
    {
        public Transform node;

        Res_Card cell;

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
            transform.localPosition = new(transform.localPosition.x, 20);
            transform.localScale = Vector3.one * 1.3f;
        }


        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            transform.localPosition = new(transform.localPosition.x, 0);
            transform.localScale = Vector3.one;
        }
    }
}

