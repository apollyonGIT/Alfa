using Common;
using UnityEngine;
using World;

namespace Battle
{
    public class BattleContext : Singleton<BattleContext>
    {
        #region outter
        public int max_hp;
        public int hp;
        public VID pos;

        public Vector2[] fly_pos_array_data;
        public VID[] fly_pos_array => VID.convert(fly_pos_array_data, pos);

        public EN_player_status player_status;
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
            BattleSceneRoot.instance.monoRoot.gameObject.SetActive(false);

            var camera_helper = World_Camera_Helper.instance;
            {
                camera_helper.move_to_pos(m_ori_camera_pos);
                camera_helper.reset_size();
            }
        }
    }
}

