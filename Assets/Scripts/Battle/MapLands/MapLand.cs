using Foundation;
using UnityEngine;

namespace Battle.MapLands
{
    public class MapLand : Model<MapLand, IMapLandView>
    {
        public int vid;

        public Vector2 view_pos;

        public MapLandMgr mgr;

        //==================================================================================================

        public MapLand(MapLandMgr mgr, int x, int y)
        {
            this.mgr = mgr;

            vid = y * 100 + x;
            view_pos = new(x, y);
        }
    }
}

