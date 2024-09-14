using Common;
using System.Collections.Generic;

namespace Battle.Decks
{
    public class DeckPD : Producer
    {
        public override IMgr imgr => mgr;
        DeckMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("DeckMgr", priority);

            foreach (var cell in cells())
            {
                mgr.add_cell(cell);
            }
        }


        public override void call()
        {
        }


        IEnumerable<Deck> cells()
        {
            var rs = DB.instance.deck.records;

            foreach (var r in rs)
            {
                for (int i = 0; i < r.f_count; i++)
                {
                    yield return new(mgr, r.f_id);
                }
            }
        }
    }
}

