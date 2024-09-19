using Cards.BattleCards;
using Common;
using Foundation;
using UnityEngine;

namespace Battle.Cards
{
    public class Hold : Model<Hold, IHoldView>
    {
        public Card card;
        public HoldMgr mgr;

        //==================================================================================================

        public Hold(HoldMgr mgr, params object[] args)
        {
            this.mgr = mgr;

            card = (Card)args[0];
        }


        public void use(params object[] args)
        {
            mgr.remove_cell(this);

            //创建驻场牌
            var slot_id = (int)args[0];
            Mission.instance.try_get_mgr("BattleCardMgr", out BattleCardMgr battleCardMgr);
            battleCardMgr.pd.create_cells(slot_id, card);
        }
    }
}

