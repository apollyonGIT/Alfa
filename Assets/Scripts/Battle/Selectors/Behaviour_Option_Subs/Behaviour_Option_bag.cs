using Common;
using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_bag : Behaviour_Option
    {

        //==================================================================================================

        public Behaviour_Option_bag(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void init()
        {
            m_skill_id = 198000001u;

            Battle_DB.instance.skill.try_get(199000002u, out var r);
            Common_DS.instance.add(m_skill_id.ToString(), r);
        }
    }
}

