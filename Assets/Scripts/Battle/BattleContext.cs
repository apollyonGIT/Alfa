using Common;

namespace Battle
{
    public class BattleContext : Singleton<BattleContext>
    {
        #region outter
        public VID? foucs_pos = null; //焦点位置

        #endregion

        //==================================================================================================

        public static void init()
        {
        }


        public static void fini()
        {
        }
    }
}

