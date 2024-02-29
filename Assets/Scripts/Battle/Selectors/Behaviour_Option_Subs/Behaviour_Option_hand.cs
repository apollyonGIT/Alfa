using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("hand");
        }
    }
}

