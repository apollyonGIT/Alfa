using World;

namespace Battle
{
    public class BattleContext : Common.Singleton<BattleContext>
    {
        public VID selected_chess_vid;
        public int energy;

        //==================================================================================================

        public static void end_battle(WorldContext ctx)
        {
            //ctx.battle_ret = ;
        }
    }
}

