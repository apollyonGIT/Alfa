using Foundation;
using UnityEngine;

namespace Battle.MapLands
{
    public class MapLand : Model<MapLand, IMapLandView>
    {
        public int v_id;

        public Vector2 view_pos;

        //==================================================================================================

        public MapLand(int x, int y)
        {
            v_id = y * 100 + x;
            view_pos = new(x, y);
        }
    }
}

