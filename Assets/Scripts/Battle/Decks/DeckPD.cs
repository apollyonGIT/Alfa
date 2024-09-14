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
            for (int i = 0; i < 6; i++)
            {
                yield return new(mgr, 300101101u);
            }

            for (int i = 0; i < 6; i++)
            {
                yield return new(mgr, 300201101u);
            }

            for (int i = 0; i < 6; i++)
            {
                yield return new(mgr, 300301101u);
            }

            for (int i = 0; i < 6; i++)
            {
                yield return new(mgr, 300401101u);
            }

            for (int i = 0; i < 6; i++)
            {
                yield return new(mgr, 300501101u);
            }
        }
    }
}

