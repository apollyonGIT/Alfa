using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_foot : Behaviour_Option
    {

        //==================================================================================================

        public Behaviour_Option_foot(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void init()
        {
            m_skill_id = _desc.f_id;
        }


        public void cast_sit()
        {
            Debug.Log("sit");
        }
    }
}

