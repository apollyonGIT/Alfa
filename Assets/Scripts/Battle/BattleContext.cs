using Common;
using World;

namespace Battle
{
    public class BattleContext : Singleton<BattleContext>
    {
        #region outter
        public VID? foucs_pos = null; //焦点位置

        public int res_cards_count;
        public int selected_res_cards_count;

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

