using Foundation;

namespace Battle.Decks
{
    public class Deck : Model<Deck, IDeckView>
    {

        public DeckMgr mgr;

        //==================================================================================================

        public Deck(DeckMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }
    }
}

