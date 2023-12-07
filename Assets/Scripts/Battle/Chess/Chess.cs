using Foundation;
using UnityEngine;

namespace Battle.Chess
{
    public class Chess : Model<Chess, IChessView>
    {
        public VID vid;

        public Vector2 view_pos => VID.convert(vid);

        //==================================================================================================

        public Chess(VID vid)
        {
            this.vid = vid;
        }
    }
}

