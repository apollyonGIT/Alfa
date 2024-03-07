using Common;
using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_hand : Behaviour_Option
    {

        //==================================================================================================

        public Behaviour_Option_hand(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void on_click()
        {
            base.on_click();

            Mission.instance.try_get_mgr("SkillMgr", out var skill_mgr);
            skill_mgr.GetType().GetMethod("load_from_db")?.Invoke(skill_mgr, new object[] { this });
        }


        public void cast_nova()
        {
            Debug.Log("nova");
        }
    }
}

