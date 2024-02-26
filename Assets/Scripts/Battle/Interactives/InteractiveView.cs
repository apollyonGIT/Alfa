using Common;
using Foundation;

namespace Battle.Interactives
{
    public class InteractiveView : View, IInteractiveView
    {
        Interactive cell;
        public override object vmgr => cell.mgr;
        public override object vcell => cell;

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

