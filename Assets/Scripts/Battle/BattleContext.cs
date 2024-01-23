using Common;
using World;

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
            var wctx = WorldContext.instance;
        }


        public static void fini()
        {
            var wctx = WorldContext.instance;
        }
    }
}

