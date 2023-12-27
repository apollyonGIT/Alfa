using Foundation;
using UnityEngine;

namespace Battle.BF_Lands
{
    public class BF_LandView : MonoBehaviour, IBF_LandView
    {
        BF_Land cell;

        //==================================================================================================

        void IModelView<BF_Land>.attach(BF_Land cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<BF_Land>.detach(BF_Land cell)
        {
            this.cell = null;
        }


        void IModelView<BF_Land>.shift(BF_Land old_cell, BF_Land new_cell)
        {
        }
    }
}

