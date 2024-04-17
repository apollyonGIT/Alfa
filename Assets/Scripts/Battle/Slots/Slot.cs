using Foundation;
using UnityEngine;

namespace Battle.Slots
{
    public class Slot : Model<Slot, ISlotView>
    {
        public int id;
        public Vector2 view_pos;

        public SlotMgr mgr;

        //==================================================================================================

        public Slot(SlotMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
            
            id = (int)args[0];

            var x = id % 5;
            var y = (id - x) / 5;

            view_pos = new(x * 7.5f - 15, y * 5 - 5);
        }
    }
}

