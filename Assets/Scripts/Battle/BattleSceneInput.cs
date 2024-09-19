using Common;
using UnityEngine;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviour
    {
        public void OnLeftMouseClick()
        {
            Battle_Mouse_Helper.do_hit_view_method<InteractiveView>("notify_on_left_click");
        }


        public void OnRightMouseClick()
        {
            Battle_Mouse_Helper.do_hit_view_method<InteractiveView>("notify_on_right_click");
        }


        public void OnUseCardInSlot()
        {
            Battle_Mouse_Helper.do_hit_view_method<InteractiveView>("notify_on_UseCardInSlot");
        }
    }
}

