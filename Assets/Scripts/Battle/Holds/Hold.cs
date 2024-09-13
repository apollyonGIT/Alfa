using AutoCode.Tables;
using Foundation;

namespace Battle.Holds
{
    public class Hold : Model<Hold, IHoldView>
    {
        public Card.Record _desc;

        public HoldMgr mgr;

        //==================================================================================================

        public Hold(HoldMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (uint)args[0];
            World.DB.instance.card.try_get(id, out _desc);
        }


        public void use()
        {
            mgr.remove_cell(this);
        }
    }
}

