using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Dices
{
    public class DicePD : Producer
    {
        public DiceView model;

        public override IMgr imgr => mgr;
        DiceMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("DiceMgr", priority);

            call();
        }


        public override void call()
        {
            mgr.remove_cells();

            foreach (var cell in cells())
            {
                mgr.add_cell(cell);

                var view = Instantiate(model, transform);
                cell.add_view(view);
            }
        }


        IEnumerable<Dice> cells()
        {
            for (int i = 0; i < 3; i++)
            {
                var value = DiceMgr.roll();
                yield return new(mgr, value);
            }
        }
    }
}

