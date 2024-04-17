using Foundation;
using UnityEngine;

namespace Battle.Cards
{
    public class Card : Model<Card, ICardView>
    {
        public int seq;
        public Vector2 view_pos;

        public CardMgr mgr;

        //==================================================================================================

        public Card(CardMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            seq = (int)args[0];
            view_pos = new(seq * 160 - 320 ,0);
        }
    }
}

