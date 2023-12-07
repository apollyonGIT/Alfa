using Common;
using System.Collections.Generic;

namespace Battle.Chess
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

            foreach (var cell in cells(1, 2))
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


        IEnumerable<Chess> cells(int x, int y)
        {
            VID vid = VID.init(x, y);
            yield return new(vid);
        }
    }
}

