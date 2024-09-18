using Common;
using Foundation;

namespace Battle.Cards
{
    public class Hold : Model<Hold, IHoldView>
    {
        public Card card;
        public HoldMgr mgr;

        //==================================================================================================

        public Hold(HoldMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            card = (Card)args[0];
        }


        public void use()
        {
            mgr.remove_cell(this);
        }
    }
}

