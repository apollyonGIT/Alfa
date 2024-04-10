using Common;
using UnityEngine;
using World;

namespace Battle
{
    public class AC_Move
    {
        public static void player_move_by_step(BattleContext ctx, Vector2 dir, bool is_enter_next_turn = true)
        {
            Mission.instance.try_get_mgr("PlayerMgr", out Players.PlayerMgr player_mgr);
            player_mgr.move_by_step(ctx, dir);

            if (is_enter_next_turn)
                BattleSceneRoot.instance.next_turn();

            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr land_mgr);
            land_mgr.clear_cells_color();
        }


        public static void player_move_to_pos(BattleContext ctx, Vector2 pos, bool is_enter_next_turn = true)
        {
            Mission.instance.try_get_mgr("PlayerMgr", out Players.PlayerMgr mgr);
            mgr.move_to_pos(ctx, pos);

            if (is_enter_next_turn)
                BattleSceneRoot.instance.next_turn();

            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr land_mgr);
            land_mgr.clear_cells_color();
        }
    }
}

