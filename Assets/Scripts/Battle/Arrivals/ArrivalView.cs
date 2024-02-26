using Common;
using Foundation;
using UnityEngine;

namespace Battle.Arrivals
{
    public class ArrivalView : View, IArrivalView
    {
        public SpriteRenderer area;

        Arrival cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Arrival>.attach(Arrival cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Arrival>.detach(Arrival cell)
        {
            this.cell = null;
        }


        void IArrivalView.notify_on_change_active()
        {
            area.enabled = cell.is_active;
        }
    }
}

