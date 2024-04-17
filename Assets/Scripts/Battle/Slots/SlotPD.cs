using Common;
using System.Collections.Generic;

namespace Battle.Slots
{
    public class SlotPD : Producer
    {
        public SlotView model;

        public override IMgr imgr => mgr;
        SlotMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("SlotMgr", priority);

            foreach (var cell in cells())
            {
                var view = Instantiate(model, transform);
                cell.add_view(view);
            }
        }


        public override void call()
        {
        }


        IEnumerable<Slot> cells()
        {
            var count = 20;

            while (count-- != 0)
            {
                yield return new(mgr, count);
            }
        }
    }
}

