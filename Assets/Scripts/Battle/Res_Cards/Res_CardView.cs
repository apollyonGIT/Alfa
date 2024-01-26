using Foundation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battle.Res_Cards
{
    public class Res_CardView : MonoBehaviour, IRes_CardView, IPointerClickHandler
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


        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            ref var is_selected = ref cell.is_selected;
            is_selected = !is_selected;

            var offset = is_selected ? 25 : -25;
            var pos = transform.localPosition;
            pos.y += offset;
            transform.localPosition = pos;
        }
    }
}

