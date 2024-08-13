using Foundation;
using UnityEngine;
using Common;

namespace Scripts.BFs
{
    public class BFView : MonoBehaviour, IBFView
    {
        BF cell;

        //==================================================================================================

        void IModelView<BF>.attach(BF cell)
        {
            this.cell = cell;
        }


        void IModelView<BF>.detach(BF cell)
        {
            this.cell = null;
        }


        public void notify_on_left_click()
        {
            Debug.Log(111);
        }
    }
}

