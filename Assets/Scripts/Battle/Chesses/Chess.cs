using Foundation;
using UnityEngine;

namespace Battle.Chesses
{
    public class Chess : Model<Chess, IChessView>
    {
        public int vid;

        public Vector2 view_pos;

        //==================================================================================================

        public Chess(int x, int y)
        {
            vid = 100 * y + x;
            view_pos = new(x, y);
        }
    }
}

