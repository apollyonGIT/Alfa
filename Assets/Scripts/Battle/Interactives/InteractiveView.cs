using Common;
using Foundation;

namespace Battle.Interactives
{
    public class InteractiveView : InputView, IInteractiveView
    {
        Interactive cell;
        public override object iv_mgr => cell.mgr;
        public override object iv_cell => cell;

        //==================================================================================================

        void IModelView<Interactive>.attach(Interactive cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Interactive>.detach(Interactive cell)
        {
            this.cell = null;
        }
    }
}

