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
            on_click();
        }


        public override void on_click()
        {
            base.on_click();

            load_skills(this);
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

