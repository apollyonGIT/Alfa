using Common;
using UnityEngine;

namespace Battle
{
    public class Battle_Camera_Helper : Camera_Helper<Battle_Camera_Helper>
    {
        protected sealed override Camera camera => World.WorldSceneRoot.instance.mainCamera;
        protected sealed override float default_size => 7.5f;
        protected sealed override float max_size => 10f;
        protected sealed override float min_size => 4f;

        bool m_is_right_mouse_hold;
        Vector3 m_temp_pos;

        //==================================================================================================

        public void zoom(float delta_size)
        {
            change_size(delta_size);
        }


        public void drag_start()
        {
            var root = BattleSceneRoot.instance;
            if (root.valid_in_ui(out _)) return;

            m_is_right_mouse_hold = true;
            m_temp_pos = pos + (Vector3)Mouse_Helper.calc_mouse_pos(root.uiCamera);
        }


        public void drag_end()
        {
            m_is_right_mouse_hold = false;
        }


        public void dragging()
        {
            if (!m_is_right_mouse_hold) return;

            var pos = m_temp_pos - (Vector3)Mouse_Helper.calc_mouse_pos(BattleSceneRoot.instance.uiCamera);
            move_to_pos(pos);
        }
    }
}

