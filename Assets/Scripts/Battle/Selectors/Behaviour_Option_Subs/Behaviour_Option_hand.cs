using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_hand : Behaviour_Option
    {

        //==================================================================================================

        public Behaviour_Option_hand(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void init()
        {
            m_skill_id = _desc.f_id;
        }


        public void cast_pickup()
        {
            Debug.Log("pickup");
        }


        public void cast_push()
        {
            Debug.Log("push");
        }
    }
}

