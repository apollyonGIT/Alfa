using Common;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_Static : Behaviour_Option
    {

        //==================================================================================================

        public Behaviour_Option_Static(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void on_left_click()
        {
            base.on_left_click();

            Mission.instance.try_get_mgr("SkillMgr", out var skill_mgr);
            skill_mgr.GetType().GetMethod("load_from_db")?.Invoke(skill_mgr, new object[] { this });
        }
    }
}

