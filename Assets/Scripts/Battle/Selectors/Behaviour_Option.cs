using Common;
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


        public virtual void init()
        { 
        }


        public virtual void on_click()
        {
            mgr.reset();

            foreach (var view in views)
            {
                view.notify_on_select();
            }

            Mission.instance.try_get_mgr("SkillMgr", out var skill_mgr);
            skill_mgr.GetType().GetMethod("reset")?.Invoke(skill_mgr, null);
        }


        public virtual void on_cancel()
        {
            foreach (var view in views)
            {
                view.notify_on_cancel();
            }
        }
    }
}

