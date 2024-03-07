using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option_miracle : Behaviour_Option_Dyn
    {

        //==================================================================================================

        public Behaviour_Option_miracle(Behaviour_OptionMgr mgr, params object[] args) : base(mgr, args)
        {
        }


        public override void init()
        {
            m_data.Add(0, new string[] { "load(0,冰霜术,)", "cast_nova()" });

            on_left_click();
        }


        public void cast_nova()
        {
            Debug.Log("nova");
        }
    }
}

