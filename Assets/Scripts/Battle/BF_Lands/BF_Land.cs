using Foundation;
using UnityEngine;

namespace Battle.BF_Lands
{
    public class BF_Land : Model<BF_Land, IBF_LandView>
    {
        public VID vid;
        public Vector2 view_pos => new(vid.x, vid.y);

        //==================================================================================================

        public BF_Land(VID vid)
        {
            this.vid = vid;
        }
    }
}

