using AutoCode.Tables;
using Foundation;

namespace Battle.Decks
{
    public class Deck : Model<Deck, IDeckView>
    {
        public Card.Record _desc;

        public DeckMgr mgr;

        //==================================================================================================

        public Deck(DeckMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (uint)args[0];
            World.DB.instance.card.try_get(id, out _desc);
        }
    }
}

