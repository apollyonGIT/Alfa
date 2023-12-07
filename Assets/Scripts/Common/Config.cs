using Foundation.Tables;
using UnityEngine;

namespace Common
{
    [CreateAssetMenu(menuName = "GameConfig", fileName = "GameConfig")]
    public class Config : ScriptableObject
    {
        #region codes
        public static Config current
        {
            get
            {
                if (s_current == null)
                {
                    s_current = CreateInstance<Config>();
                }
                return s_current;
            }
        }
        private static Config s_current;
        private void OnEnable()
        {
            s_current = this;
        }
        private void OnDisable()
        {
            if (ReferenceEquals(s_current, this))
            {
                s_current = null;
            }
        }
        #endregion


        #region const
        //帧率
        public const int PHYSICS_TICKS_PER_SECOND = 120;
        public const float PHYSICS_TICK_DELTA_TIME = 1f / PHYSICS_TICKS_PER_SECOND;

        //表达式转换器
        public static ExprTreeConverter handcard_converter = new("Battle.HandCards.Funcs.", ", Battle", "Battle.HandCards.Funcs.", ", Battle");

        //mapland大小
        public const int mapland_limit_x = 8;
        public const int mapland_limit_y = 8;

        public const int map_max_x = 8;
        public const int map_max_y = 8;
        #endregion


        #region internal_setting
        //tick优先级
        public const int ChessMgr_Player_Priority = 1;
        public const int ChessMgr_Enemy_Priority = 2;

        //tick管理类
        public const string MapLandMgr_Name = "MapLandMgr";
        public const string TerritoryMgr_Name = "TerritoryMgr";

        public const string HandCardMgr_Name = "HandCardMgr";

        public const string ChessMgr_Player_Name = "ChessMgr_Player";
        public const string ChessMgr_Enemy_Name = "ChessMgr_Enemy";

        public const string AttackAreaMgr_Name = "AttackAreaMgr";

        //普通管理类

        #endregion


        #region outter_prms
        #endregion
    }
}

