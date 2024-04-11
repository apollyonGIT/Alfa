using Common;
using System.Linq;
using UnityEngine;

namespace Battle
{
    public class AC_Move
    {
        public static void player_move_by_step(BattleContext ctx, Vector2 dir, bool is_enter_next_turn = true)
        {
            if (!player_move_before(dir + ctx.pos)) return;

            Entity_Helper.move_by_step(ref ctx.pos, dir);
            player_move_after(is_enter_next_turn);
        }


        public static void player_move_to_pos(BattleContext ctx, Vector2 pos, bool is_enter_next_turn = true)
        {
            if (!player_move_before(pos)) return;

            Entity_Helper.move_to_pos(ref ctx.pos, pos);
            player_move_after(is_enter_next_turn);
        }


        static void player_move_after(bool is_enter_next_turn)
        {
            if (is_enter_next_turn)
                BattleSceneRoot.instance.next_turn();

            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr land_mgr);
            land_mgr.clear_cells_color();
        }


        static bool player_move_before(VID pos)
        {
            var entity_pos_array = Entity_Helper.instance.entity_pos_array;
            foreach (var entity_pos in entity_pos_array)
            {
                if (entity_pos == pos)
                    return false;
            }

            return true;
        }
    }
}

