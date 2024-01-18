using Battle.Tricks;
using Foundation;
using UnityEngine;

namespace Battle.Players
{
    public class Player : Model<Player, IPlayerView>, IChess
    {
        public VID pos;
        public Vector2 view_pos => (Vector2)pos;

        public PlayerMgr mgr;

        //==================================================================================================

        public Player(PlayerMgr mgr, params object[] args)
        {
            this.mgr = mgr;

            pos = (VID)args[0];
        }


        void IChess.move(ref VID pos, Vector2 step)
        {
            var from = pos;
            Chess_Helper.opti_move(ref pos, step);

            mgr.remove_cell(from);
            mgr.add_cell(this);
        }
    }
}

