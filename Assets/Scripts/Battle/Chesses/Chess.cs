using Battle.Helpers;
using Foundation;
using UnityEngine;

namespace Battle.Chesses
{
    public class Chess : Model<Chess, IChessView>
    {
        public int vid;

        public Vector2 view_pos => calc_view_pos();

        public ChessMgr mgr;

        //==================================================================================================

        public Chess(ChessMgr mgr, int x, int y)
        {
            this.mgr = mgr;

            SquareMap_Helper.encode_vid(x, y, out vid);
        }


        Vector2 calc_view_pos()
        {
            SquareMap_Helper.decode_vid(vid, out var x, out var y);
            return new(x, y);            
        }
    }
}

