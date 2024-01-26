using Foundation;
using UnityEngine;

namespace Battle.Lands
{
    public class LandView : MonoBehaviour, ILandView
    {
        Land cell;

        //==================================================================================================

        void IModelView<Land>.attach(Land cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Land>.detach(Land cell)
        {
            this.cell = null;
        }
    }
}

