using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Res_Cards
{
    public class Res_CardPD : Producer
    {
        public RectTransform rect;

        public int count;
        public Res_CardView model_view;

        public override IMgr imgr => mgr;
        Res_CardMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("Res_CardMgr", priority);

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


        IEnumerable<Res_Card> cells(Res_CardMgr mgr)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new(mgr);
            }
        }


        private void Update()
        {
            if (mgr == null) return;

            rect.sizeDelta = mgr.node_pos;
        }
    }
}

