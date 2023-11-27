using Foundation;
using UnityEngine;

namespace Battle.HandCards
{
    public class HandCard : Model<HandCard, IHandCardView>
    {
        public int seq;
        public AutoCode.Tables.Card.Record _desc;

        public Vector2 view_pos => new(seq * 160, 0);

        //==================================================================================================

        public HandCard(uint id)
        {
            Battle_DB.instance.card.try_get(id, out _desc);
        }
    }
}

