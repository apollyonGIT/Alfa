using World;

namespace Battle
{
    public class BattleContext : Common.Singleton<BattleContext>
    {
        public VID selected_chess_vid;

        //==================================================================================================

        public static void end_battle(WorldContext ctx)
        {
            //ctx.battle_ret = ;
        }
    }
}

