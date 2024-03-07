using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_foot : Behaviour_Option_Static
    {

        //==================================================================================================

        public Behaviour_Option_foot(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public void cast_sit()
        {
            Debug.Log("sit");
        }
    }
}

