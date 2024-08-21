using Foundation;

namespace Battle.Cards
{
    public class Card : Model<Card, ICardView>
    {
        public EN_Card_Type type;

        public uint id;
        public AutoCode.Tables.Card.Record _desc;

        public int seq => mgr.calc_seq(this);

        public CardMgr mgr;

        //==================================================================================================

        public Card(CardMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            type = (EN_Card_Type)args[0];
            id = (uint)args[1];

            Battle_DB.instance.card.try_get(id, out _desc);
        }
    }
}

