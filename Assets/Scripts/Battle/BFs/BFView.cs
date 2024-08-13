using Foundation;
using UnityEngine;

namespace Battle.BFs
{
    public class BFView : MonoBehaviour, IBFView
    {
        BF cell;

        //==================================================================================================

        void IModelView<BF>.attach(BF cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<BF>.detach(BF cell)
        {
            this.cell = null;
        }


        public void notify_on_left_click()
        {
            Debug.Log(cell.pos);
        }
    }
}

