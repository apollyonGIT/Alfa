using Foundation;
using UnityEngine;

namespace Battle.Arrivals
{
    public class ArrivalView : MonoBehaviour, IArrivalView
    {
        public SpriteRenderer area;

        Arrival cell;

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

