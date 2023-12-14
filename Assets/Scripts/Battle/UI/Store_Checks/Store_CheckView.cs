using Foundation;
using UnityEngine;

namespace Battle.Store_Checks
{
    public class Store_CheckView : MonoBehaviour, IStore_CheckView
    {
        Store_Check cell;

        //==================================================================================================

        void IModelView<Store_Check>.attach(Store_Check cell)
        {
            this.cell = cell;
        }


        void IModelView<Store_Check>.detach(Store_Check cell)
        {
            this.cell = null;
        }


        void IModelView<Store_Check>.shift(Store_Check old_cell, Store_Check new_cell)
        {
        }
    }
}

