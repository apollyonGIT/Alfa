using Common;
using Foundation;
using UnityEngine;

namespace Battle.Players
{
    public class Player : Model<Player, IPlayerView>
    {
        public Vector2 view_pos => (Vector2)pos * 2 + new Vector2(0.5f, 0.5f);
        public VID pos => ctx.pos;

        public int dmg => calc_dmg();

        public AutoCode.Tables.Player.Record _desc;
        public PlayerMgr mgr;

        public BattleContext ctx;

        //==================================================================================================

        public Player(PlayerMgr mgr, params object[] args)
        {
            this.mgr = mgr;
            ctx = BattleContext.instance;

            var id = (uint)args[0];
            Battle_DB.instance.player.try_get(id, out _desc);

            EX_Utility.try_load_asset(_desc.f_fly_asset_path, out Scope_Asset asset);
            ctx.fly_pos_array_data = asset.pos_array;
            ctx.pos = (VID)args[1];
        }


        public void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }


        public int calc_dmg()
        {
            return 10;
        }
    }
}

