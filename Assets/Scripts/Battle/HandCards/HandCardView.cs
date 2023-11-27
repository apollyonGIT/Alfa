using Foundation;
using UnityEngine;

namespace Battle.HandCards
{
    public class HandCardView : MonoBehaviour, IHandCardView
    {
        HandCard cell;

        //==================================================================================================

        void IModelView<HandCard>.attach(HandCard cell)
        {
            this.cell = cell;
        }


        void IModelView<HandCard>.detach(HandCard cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }


        void IModelView<HandCard>.shift(HandCard old_cell, HandCard new_cell)
        {
        }


        void IHandCardView.notify_on_tick1()
        {
            transform.localPosition = cell.view_pos;
        }
    }
}

