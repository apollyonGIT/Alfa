using Common;
using System.Collections.Generic;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_Dyn : Behaviour_Option, ISkillMono_Dyn
    {
        Dictionary<int, string[]> ISkillMono_Dyn.data => m_data;
        protected Dictionary<int, string[]> m_data = new();

        //==================================================================================================

        public Behaviour_Option_Dyn(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void init()
        {
            //m_data.Add(0, new string[] { "load(0,凝神,)", "cast_nova()" });
        }


        public override void on_left_click()
        {
            base.on_left_click();

            Mission.instance.try_get_mgr("SkillMgr", out var skill_mgr);
            skill_mgr.GetType().GetMethod("load_from_data")?.Invoke(skill_mgr, new object[] { this });
        }
    }
}

