using Common.Opr_Module;
using Foundation;
using UnityEngine;

namespace Battle.Interactives
{
    public class InteractiveView : OprTargetView, IInteractiveView
    {
        Interactive cell;

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


        void IModelView<Interactive>.shift(Interactive old_cell, Interactive new_cell)
        {
        }


        public override void notify_on_click()
        {
            cell.mgr.do_on_click(cell);
        }
    }
}

