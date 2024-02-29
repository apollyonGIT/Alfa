using Common;
using UnityEngine;

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


        public void cast_nova()
        {
            Debug.Log("nova");
        }


        public void cast_twine()
        {
            Debug.Log("twine");
        }
    }
}

