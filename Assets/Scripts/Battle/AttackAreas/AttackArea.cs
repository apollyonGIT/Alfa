using Battle.Helpers;
using Foundation;
using UnityEngine;

namespace Battle.AttackAreas
{
    public class AttackArea : Model<AttackArea, IAttackAreaView>
    {
        public int vid;
        public Vector2 view_pos;

        //==================================================================================================

        public AttackArea(int vid)
        {
            this.vid = vid;

            SquareMap_Helper.decode_vid(vid, out var x, out var y);
            view_pos = new(x, y);
        }
    }
}

