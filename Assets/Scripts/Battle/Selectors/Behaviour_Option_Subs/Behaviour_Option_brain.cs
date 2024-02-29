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


        public override void on_click()
        {
            base.on_click();
        }
    }
}

