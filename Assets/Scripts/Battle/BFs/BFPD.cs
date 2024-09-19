using Common;

namespace Battle.BFs
{
    public class BFPD : Producer
    {
        public BFView model;

        public override IMgr imgr => null;

        //==================================================================================================

        public override void init(int priority)
        {
            var view = Instantiate(model, transform);
            view.init();
        }


        public override void call()
        {
        }
    }
}

