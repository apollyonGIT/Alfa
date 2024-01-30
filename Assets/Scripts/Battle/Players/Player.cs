using Common;
using Common.Table_Module;
using Foundation;
using UnityEngine;
using System;

namespace Battle.Players
{
    public class Player : Model<Player, IPlayerView>
    {
        public VID pos;
        public Vector2 view_pos => (Vector2)pos;

        public int hp = 100;
        public int dmg => calc_dmg();

        public VID[] arrival_pos_array => VID.convert(m_arrival_pos_array, pos);
        Vector2[] m_arrival_pos_array;

        public AutoCode.Tables.Monster.Record _desc;
        public PlayerMgr mgr;

        //==================================================================================================

        public Player(PlayerMgr mgr, params object[] args)
        {
            this.mgr = mgr;
            
            pos = (VID)args[0];

            var id = (int)args[1];
            World.World_DB.instance.monster.try_get((uint)id, out _desc);

            EX_Utility.try_load_asset(_desc.f_arrival_asset_path, out Arrival_Asset asset);
            m_arrival_pos_array = asset.pos_array;

            var can_move = (bool)Table_Utility.do_expr(_desc.f_move_condition, this, new Type[] { Config.type_float, Config.type_string });
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


        public bool move_condition(float f, string s)
        {
            Debug.Log(f);
            return false;
        }
    }
}

