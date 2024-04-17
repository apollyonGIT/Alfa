using Foundation;
using UnityEngine;
using Common;
using UnityEngine.EventSystems;

namespace Battle.Cards
{
    public class CardView : View, ICardView, IPointerEnterHandler
    {
        Card cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Card>.attach(Card cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Card>.detach(Card cell)
        {
            this.cell = null;
        }


        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log(111);
        }
    }
}

