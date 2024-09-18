using Common;

namespace Battle.Cards
{
    public class Card
    {
        public ENUM.Card_Status status;

        public AutoCode.Tables.Card.Record _desc;
        public DeckMgr mgr;

        //==================================================================================================

        public Card(DeckMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (uint)args[0];
            DB.instance.card.try_get(id, out _desc);
        }
    }
}

