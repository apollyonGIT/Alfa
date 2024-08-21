using Common;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace Battle.Cards
{
    public class CardPD : Producer
    {
        public EN_Card_Type type;
        public int count = 5;

        public CardView model;

        public override IMgr imgr => mgr;
        CardMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("CardMgr", priority);

            foreach (var cell in cells())
            {
                mgr.add_cell(cell);

                var view = Instantiate(model, transform);
                cell.add_view(view);
            }
        }


        public override void call()
        {
        }


        IEnumerable<Card> cells()
        {
            for (int i = 0; i < count; i++)
            {
                yield return new(mgr, type);
            }
        }
    }
}

