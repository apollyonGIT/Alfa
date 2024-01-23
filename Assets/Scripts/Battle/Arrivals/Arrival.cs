using Foundation;
using UnityEngine;

namespace Battle.Arrivals
{
    public class Arrival : Model<Arrival, IArrivalView>
    {
        public VID pos;

        public Vector2 view_pos => (Vector2)pos;
        public bool is_active;

        public ArrivalMgr mgr;

        //==================================================================================================

        public Arrival(ArrivalMgr mgr,  params object[] args)
        {
            pos = (VID)args[0];

            this.mgr = mgr;
        }


        public void change_active(bool need_active)
        {
            is_active = need_active;

            foreach (var view in views)
            {
                view.notify_on_change_active();
            }
        }
    }
}

