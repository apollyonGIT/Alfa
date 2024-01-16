using Foundation;
using UnityEngine;

namespace Battle.Lands
{
    public class Land : Model<Land, ILandView>
    {
        public VID vid;
        public Vector2 view_pos => new(vid.x, vid.y);

        //==================================================================================================

        public Land(VID vid)
        {
            this.vid = vid;
        }
    }
}

