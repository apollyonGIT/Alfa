using Foundation;
using UnityEngine;

namespace Battle.Territorys
{
    public class TerritoryView : MonoBehaviour, ITerritoryView
    {
        Territory cell;

        //==================================================================================================

        void IModelView<Territory>.attach(Territory cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Territory>.detach(Territory cell)
        {
            this.cell = null;
        }


        void IModelView<Territory>.shift(Territory old_cell, Territory new_cell)
        {
        }
    }
}

