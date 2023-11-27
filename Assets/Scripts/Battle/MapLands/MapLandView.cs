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

            transform.localPosition = cell.view_pos;
            gameObject.name = $"{cell.v_id}";
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

