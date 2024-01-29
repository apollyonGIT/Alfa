using Foundation;
using UnityEngine;

namespace Battle.Players
{
    public class Player : Model<Player, IPlayerView>
    {
        public VID pos;
        public Vector2 view_pos => (Vector2)pos;

        public int hp = 100;
        public int dmg => calc_dmg();

        public PlayerMgr mgr;

        //==================================================================================================

        public Player(PlayerMgr mgr, params object[] args)
        {
            this.mgr = mgr;

            pos = (VID)args[0];
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

