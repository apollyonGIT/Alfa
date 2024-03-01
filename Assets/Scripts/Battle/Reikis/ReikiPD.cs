using Common;

namespace Battle.Reikis
{
    public class ReikiPD : Producer
    {
        public ReikiView model_view;

        public override IMgr imgr => mgr;
        ReikiMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("ReikiMgr", priority);
            
            var view = Instantiate(model_view, transform);
            mgr.add_view(view);
        }


        public override void call()
        {
        }
    }
}

