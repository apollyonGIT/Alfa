using Foundation;
using UnityEngine;
using Common;

namespace Battle.Slots
{
    public class SlotView : View, ISlotView
    {
        Slot cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Slot>.attach(Slot cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Slot>.detach(Slot cell)
        {
            this.cell = null;
        }
    }
}

