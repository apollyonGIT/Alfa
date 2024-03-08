using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_miracle : Behaviour_Option
    {

        //==================================================================================================

        public Behaviour_Option_miracle(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void init()
        {
            m_skill_id = 199000001u;

            on_left_click();
        }
    }
}

