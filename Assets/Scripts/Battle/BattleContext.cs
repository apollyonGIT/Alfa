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

        public static void attach(WorldContext wctx)
        {
        }


        public static void detach(WorldContext wctx)
        {
        }
    }
}

