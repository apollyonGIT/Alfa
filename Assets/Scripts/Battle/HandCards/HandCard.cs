using Battle.HandCards.Funcs;
using Common;
using Foundation;
using UnityEngine;

namespace Battle.HandCards
{
    public class HandCard : Model<HandCard, IHandCardView>
    {
        public int seq;

        public AutoCode.Tables.Card.Record _desc;
        public IFunc use_func;

        public Vector2 view_pos;

        //==================================================================================================

        public HandCard(uint id)
        {
            Battle_DB.instance.card.try_get(id, out _desc);
            EX_Utility.expr_convert(Config.handcard_converter, _desc.f_use_func, out use_func, out _);

            //use_func?.@do();
        }


        public void reset_pos(int seq)
        {
            this.seq = seq;
            view_pos = new(seq * 160, 0);
        }
    }
}

