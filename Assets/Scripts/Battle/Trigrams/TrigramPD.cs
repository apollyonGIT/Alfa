using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Trigrams
{
    public class TrigramPD : Producer
    {
        public int trigram_max_count = 3;
        public int trigram_asign_each_turn = 5;

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

            call();
        }


        public override void call()
        {
            mgr.random_select(trigram_asign_each_turn, trigram_max_count);
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

