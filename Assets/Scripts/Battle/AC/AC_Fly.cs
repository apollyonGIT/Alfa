using Common;
using UnityEngine;

namespace Battle
{
    public class AC_Fly
    {
        public static void show_fly_area(BattleContext ctx)
        {
            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr mgr);

            if (ctx.player_status == EN_player_status.none)
            {
                foreach (var pos in ctx.fly_pos_array)
                {
                    mgr.set_cell_color(pos, Config.current.fly_area_color);
                }

                ctx.player_status = EN_player_status.show_fly_area;
                return;
            }

            mgr.clear_cells_color();
            ctx.player_status = EN_player_status.none;
        }


        public static void try_fly(BattleContext ctx, Vector2 pos)
        {
            if (ctx.player_status != EN_player_status.show_fly_area) return;

            Mission.instance.try_get_mgr("PlayerMgr", out Players.PlayerMgr player_mgr);
            player_mgr.move_to_pos(ctx, pos);

            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr land_mgr);
            land_mgr.clear_cells_color();

            ctx.player_status = EN_player_status.none;
        }
    }
}

