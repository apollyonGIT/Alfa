using Foundation;

namespace Scripts.BFs
{
    public class BF : Model<BF, IBFView>
    {

        public BFMgr mgr;

        //==================================================================================================

        public BF(BFMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }
    }
}

