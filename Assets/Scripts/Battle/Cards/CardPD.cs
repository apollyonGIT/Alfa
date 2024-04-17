using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Cards
{
    public class CardPD : Producer
    {
        public CardView model;

        public override IMgr imgr => mgr;
        CardMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("CardMgr", priority);

            foreach (var cell in cells())
            {
                var view = Instantiate(model, transform);
                cell.add_view(view);
            }
        }


        public override void call()
        {
        }


        IEnumerable<Card> cells()
        {
            var count = 0;
            while (count < 5)
            {
                yield return new(mgr, count++);
            }
        }
    }
}

