using Common;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_brain : Behaviour_Option
    {

        //==================================================================================================

        public Behaviour_Option_brain(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void init()
        {
            on_click();
        }


        public override void on_click()
        {
            base.on_click();

            Mission.instance.try_get_mgr("SkillMgr", out var skill_mgr);
            skill_mgr.try_get_cell(out var skill, new object[] { 2 });
            skill.GetType().GetMethod("load")?.Invoke(skill, new object[] { "b" });
        }
    }
}

