using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Trigrams
{
    public class TrigramPD : Producer
    {
        public float radius = 70;
        public TrigramView model_view;

        public override IMgr imgr => mgr;
        TrigramMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("TrigramMgr", priority);

            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_view, transform);
                cell.add_view(view);
            }
        }


        public override void call()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Trigram> cells(TrigramMgr mgr)
        {
            for (int i = 0; i < 8; i++)
            {
                var rad = -45 * i * Mathf.Deg2Rad;
                var dir = EX_Utility.convert_rad_to_dir(rad);
                var pos = dir * radius;

                var id = i + 3;
                id = id <= 8 ? id : id - 8;

                yield return new(mgr, id, pos, dir);
            }
        }
    }
}

