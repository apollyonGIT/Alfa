using Foundation;
using UnityEngine;

namespace Battle.Cards
{
    public class CardView : MonoBehaviour, ICardView
    {
        Card cell;

        //==================================================================================================

        void IModelView<Card>.attach(Card cell)
        {
            this.cell = cell;

            fresh();
        }


        void IModelView<Card>.detach(Card cell)
        {
            this.cell = null;
        }


        void fresh()
        {
            transform.localPosition = new(130 * cell.seq, 0);
        }
    }
}

