using Foundation;

namespace Battle.HandCards
{
    public class HandCard : Model<HandCard, IHandCardView>
    {
        public string title = "123";

        public HandCardMgr mgr;

        //==================================================================================================

        public HandCard(HandCardMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }
    }
}

