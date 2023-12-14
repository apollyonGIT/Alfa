using Foundation;
using UnityEngine;

namespace Battle.Desc_Contents
{
    public class Desc_ContentView : MonoBehaviour, IDesc_ContentView
    {
        Desc_Content cell;

        //==================================================================================================

        void IModelView<Desc_Content>.attach(Desc_Content cell)
        {
            this.cell = cell;
        }


        void IModelView<Desc_Content>.detach(Desc_Content cell)
        {
            this.cell = null;
        }


        void IModelView<Desc_Content>.shift(Desc_Content old_cell, Desc_Content new_cell)
        {
        }


        void IDesc_ContentView.notify_on_enable(bool is_enable)
        {
            gameObject.SetActive(is_enable);
        }
    }
}

