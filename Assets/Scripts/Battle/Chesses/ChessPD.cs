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

            var view = Instantiate(temp_view, transform);
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }
    }
}

