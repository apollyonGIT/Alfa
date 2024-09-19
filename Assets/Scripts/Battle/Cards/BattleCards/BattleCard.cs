using Foundation;

namespace Cards.BattleCards
{
    public class BattleCard : Model<BattleCard, IBattleCardView>
    {

        public BattleCardMgr mgr;

        //==================================================================================================

        public BattleCard(BattleCardMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }
    }
}

