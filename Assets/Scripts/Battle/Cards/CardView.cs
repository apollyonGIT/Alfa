using Foundation;
using TMPro;
using UnityEngine;

namespace Battle.Cards
{
    public class CardView : MonoBehaviour, ICardView
    {
        public TextMeshProUGUI title;

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
            title.text = cell._desc.f_name;

            transform.localPosition = new(130 * cell.seq, 0);
        }
    }
}

