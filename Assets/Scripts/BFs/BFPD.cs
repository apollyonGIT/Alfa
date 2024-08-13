using Common;

namespace Scripts.BFs
{
    public class BFPD : Producer
    {
        public override IMgr imgr => mgr;
        BFMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("BFMgr", priority);
        }


        public override void call()
        {
        }
    }
}

