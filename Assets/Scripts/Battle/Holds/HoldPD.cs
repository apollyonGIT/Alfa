using Common;
using System.Collections.Generic;

namespace Battle.Holds
{
    public class HoldPD : Producer
    {
        public HoldView model;

        public override IMgr imgr => mgr;
        HoldMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("HoldMgr", priority);

            call();
        }


        public override void call()
        {
            var count = 6 - mgr.hold_count;

            foreach (var cell in cells(count))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model, transform);
                cell.add_view(view);
            }
        }


        IEnumerable<Hold> cells(int count)
        {
            Mission.instance.try_get_mgr("DeckMgr", out Decks.DeckMgr deck_mgr);

            for (int i = 0; i < count; i++)
            {
                var id = deck_mgr.select_random_cell();
                yield return new(mgr, id);
            }
        }
    }
}

