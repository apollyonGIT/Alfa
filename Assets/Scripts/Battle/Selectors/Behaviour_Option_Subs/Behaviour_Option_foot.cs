﻿using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_foot : Behaviour_Option
    {

        //==================================================================================================

        public Behaviour_Option_foot(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void on_click()
        {
            base.on_click();

            load_skills(this);
        }
    }
}

