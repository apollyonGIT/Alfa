using AutoCode.Tables;
using Common;
using Foundation;

namespace Battle.Decks
{
    public class Deck : Model<Deck, IDeckView>
    {
        public ENUM.Card_Status status;

        public Card.Record _desc;
        public DeckMgr mgr;

        //==================================================================================================

        public Deck(DeckMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (uint)args[0];
            DB.instance.card.try_get(id, out _desc);
        }
    }
}

