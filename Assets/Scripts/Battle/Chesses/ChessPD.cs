using Common;

namespace Battle.Chesses
{
    public class ChessPD : Producer
    {
        public ChessView temp_view;

        public override IMgr imgr => mgr;
        ChessMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.ChessMgr_Player_Name);

            var e = cell();
            mgr.add_cell(e);

            var view = Instantiate(temp_view, transform);
            e.add_view(view);
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        public Chess cell()
        {
            return new(mgr, 1, 2);
        }
    }
}

