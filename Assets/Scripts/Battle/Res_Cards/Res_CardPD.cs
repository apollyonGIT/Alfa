using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Res_Cards
{
    public class Res_CardPD : Producer
    {
        public RectTransform rect;

        public int count = 6;
        public Res_CardView model_view;

        public override IMgr imgr => mgr;
        Res_CardMgr mgr;

        public int cells_distance = 130;

        public Transform res_area;
        public Transform selecting_area;
        public Transform standing;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("Res_CardMgr", priority);

            mgr.add_cells_ac = add_cells;
            mgr.add_cells();
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


        public void add_cells()
        {
            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_view, transform);
                cell.add_view(view);
                view.pd = this;
            }
        }


        private void Update()
        {
            if (mgr == null) return;

            rect.sizeDelta = mgr.node_pos * cells_distance;
        }
    }
}

