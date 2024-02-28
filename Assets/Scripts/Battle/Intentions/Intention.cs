using Foundation;

namespace Battle.Intentions
{
    public class Intention : Model<Intention, IIntentionView>
    {
        public bool is_active = true;
        public bool is_opr_access = true;

        public IntentionMgr mgr;

        //==================================================================================================

        public Intention(IntentionMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }


        public void tick()
        {
            if (!is_active)
                is_opr_access = false;
        }


        public void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }
    }
}

