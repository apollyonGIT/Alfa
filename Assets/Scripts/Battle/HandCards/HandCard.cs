using Foundation;
using UnityEngine;

namespace Battle.HandCards
{
    public class HandCard : Model<HandCard, IHandCardView>
    {
        public int seq;

        public Vector2 view_pos => new(seq * 160, 0);

        //==================================================================================================

    }
}

