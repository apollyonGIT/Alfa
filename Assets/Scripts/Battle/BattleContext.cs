using Common;
using UnityEngine;
using World;

namespace Battle
{
    public class BattleContext : Singleton<BattleContext>
    {
        #region outter
        public int max_hp;
        public int max_reiki;
        public int hp;
        public int reiki;

        public int reiki_each_turn;
        public int trigram_each_turn;

        public VID? foucs_pos = null; //焦点位置
        public object pointing_ui_obj;

        #endregion

        static Vector2 m_ori_camera_pos;

        //==================================================================================================

        public static void attach(WorldContext wctx)
        {
            m_ori_camera_pos = wctx.mainCamera_pos;
            Battle_Camera_Helper.instance.reset_size();
        }


        public static void detach(WorldContext wctx)
        {
            var camera_helper = World_Camera_Helper.instance;
            {
                camera_helper.move_to_pos(m_ori_camera_pos);
                camera_helper.reset_size();
            }
        }
    }
}

