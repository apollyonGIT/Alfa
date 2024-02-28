using Foundation;

namespace Battle.Selectors
{
    public class Selector : Model<Selector, ISelectorView>
    {
        public string id;

        public SelectorMgr mgr;

        //==================================================================================================

        public Selector(SelectorMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            id = (string)args[0];
        }


        internal void tick()
        {
        }


        internal void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }
    }
}

