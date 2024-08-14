using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.BFs
{
    public class BFPD : Producer
    {
        public BFView model;

        public override IMgr imgr => mgr;
        BFMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("BFMgr", priority);

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


        IEnumerable<BF> cells()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector2 pos = new(i, j);
                    yield return new(mgr, pos);
                }
            }
        }
    }
}

