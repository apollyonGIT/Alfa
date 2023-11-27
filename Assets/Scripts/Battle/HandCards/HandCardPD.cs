using Common;
using System.Collections.Generic;

namespace Battle.HandCards
{
    public class HandCardPD : Producer
    {
        public int count;
        public HandCardView temp_view;

        public override IMgr imgr => mgr;
        HandCardMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.HandCardMgr_Name);

            foreach (var cell in cells())
            {
                mgr.add_cell(cell);

                var view = Instantiate(temp_view, transform);
                cell.add_view(view);
            }
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<HandCard> cells()
        {
            for (int i = 0; i < count; i++)
            {
                yield return new();
            }
        }
    }
}

