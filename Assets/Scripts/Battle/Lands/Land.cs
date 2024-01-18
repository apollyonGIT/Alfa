using Foundation;
using UnityEngine;

namespace Battle.Lands
{
    public class Land : Model<Land, ILandView>
    {
        public VID pos;
        public Vector2 view_pos => (Vector2)pos;

        public LandMgr mgr;

        //==================================================================================================

        public Land(LandMgr mgr, params object[] args)
        {
            this.mgr = mgr;

            pos = (VID)args[0];
        }
    }
}

