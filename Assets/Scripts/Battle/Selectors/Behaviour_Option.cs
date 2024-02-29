using Foundation;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option : Model<Behaviour_Option, ISelectorView>
    {
        public string id;

        public Behaviour_OptionMgr mgr;

        //==================================================================================================

        public Behaviour_Option(Behaviour_OptionMgr mgr,  params object[] args)
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


        public virtual void on_click()
        { 
        }
    }
}

