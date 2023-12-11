using Common;
using System.Collections.Generic;

namespace Battle.Chesses
{
    public class ChessPD : Producer
    {
        public ChessView temp_view_player;

        public override IMgr imgr => mgr;
        ChessMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.ChessMgr_Player_Name);

            foreach (var cell in cells())
            {
                var view = Instantiate(temp_view_player, transform);
                cell.add_view(view);

                mgr.add_cell(cell);
            }
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Chess> cells()
        {
            VID vid = VID.init(1, 2);
            yield return new(vid, 1);

            vid = VID.init(4, 4);
            yield return new(vid, 1);
        }
    }
}

