using Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.Battle_Fields
{
    public class Battle_FieldPD : Producer
    {
        public Battle_FieldView model;
        public Vector2Int[] coordinates;

        public override IMgr imgr => mgr;
        Battle_FieldMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("Battle_FieldMgr", priority);

            add_cells(mgr);
        }


        public override void call()
        {
            mgr.remove_cells();

            add_cells(mgr);
        }


        IEnumerable<Battle_Field> cells(Battle_FieldMgr mgr)
        {
            Hexagon id;

            foreach (var pos in coordinates)
            {
                id = Hexagon.xy_2_hex(pos);
                yield return new(mgr, id);
            }
        }


        public void add_cells(Battle_FieldMgr mgr)
        {
            foreach (var (cell, index) in cells(mgr).Select((value, i) => (value, i)))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model, transform);
                cell.add_view(view);
                view.name = index.ToString();
            }
        }
    }
}

