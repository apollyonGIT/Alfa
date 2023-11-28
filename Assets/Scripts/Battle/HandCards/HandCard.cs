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

        public Vector2 view_init_pos => new(seq * 160, 0);

        public HandCardMgr mgr;

        //==================================================================================================

        public HandCard(uint id)
        {
            Battle_DB.instance.card.try_get(id, out _desc);
            EX_Utility.expr_convert(Config.handcard_converter, _desc.f_use_func, out use_func, out _);
        }


        public void reset_pos()
        {
            foreach (var view in views)
            {
                view.notify_on_reset_pos();
            }
        }
    }
}

