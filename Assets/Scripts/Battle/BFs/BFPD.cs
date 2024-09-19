using Common;
using Foundation;

namespace Battle.BFs
{
    public class BFPD : Producer
    {
        public BFView model;

        public override IMgr imgr => null;

        //==================================================================================================

        public override void init(int priority)
        {
            Instantiate(model, transform);
        }


        public override void call()
        {
        }
    }
}

