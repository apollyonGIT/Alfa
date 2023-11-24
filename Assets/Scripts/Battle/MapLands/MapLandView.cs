using Foundation;
using UnityEngine;

namespace Battle.MapLands
{
    public class MapLandView : MonoBehaviour, IMapLandView
    {
        MapLand cell;

        //==================================================================================================

        void IModelView<MapLand>.attach(MapLand cell)
        {
            this.cell = cell;
        }


        void IModelView<MapLand>.detach(MapLand cell)
        {
            this.cell = null;
        }


        void IModelView<MapLand>.shift(MapLand old_cell, MapLand new_cell)
        {
        }
    }
}

