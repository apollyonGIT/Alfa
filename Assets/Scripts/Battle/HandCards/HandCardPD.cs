using Common;
using System.Collections.Generic;

namespace Battle.HandCards
{
    public class HandCardPD : Producer
    {
        public HandCardView model;

        public override IMgr imgr => mgr;
        HandCardMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("HandCardMgr", priority);

            call();
        }


        public override void call()
        {
            var count = 6 - mgr.current_handcard_count;

            foreach (var cell in cells(count))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model, transform);
                cell.add_view(view);
            }
        }


        IEnumerable<HandCard> cells(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new(mgr);
            }
        }
    }
}

