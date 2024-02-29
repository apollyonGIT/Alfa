using Foundation;
using static AutoCode.Tables.BehaviourOption;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option : Model<Behaviour_Option, ISelectorView>
    {
        public Record _desc;

        public Behaviour_OptionMgr mgr;

        //==================================================================================================

        public Behaviour_Option(Behaviour_OptionMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (string)args[0];
            Battle_DB.instance.behaviour_option.try_get(id, out _desc);
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

