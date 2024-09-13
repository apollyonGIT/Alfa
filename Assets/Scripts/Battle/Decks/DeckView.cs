using Foundation;
using UnityEngine;
using Common;

namespace Battle.Decks
{
    public class DeckView : MonoBehaviour, IDeckView
    {
        Deck cell;

        //==================================================================================================

        void IModelView<Deck>.attach(Deck cell)
        {
            this.cell = cell;
        }


        void IModelView<Deck>.detach(Deck cell)
        {
            this.cell = null;
        }
    }
}

