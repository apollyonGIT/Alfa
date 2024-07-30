using Common;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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

            //foreach (var pos in coordinates)
            //{
            //    id = Hexagon.xy_2_hex(pos);
            //    yield return new(mgr, id);
            //}

            id = Hexagon.xy_2_hex(2, 2);
            yield return new(mgr, id);

            //yield return new(mgr, id.left());
            //yield return new(mgr, id.left_up());
            //yield return new(mgr, id.left_down());

            //yield return new(mgr, id.right());
            //yield return new(mgr, id.right_up());
            //yield return new(mgr, id.right_down());
        }


        public void add_cells(Battle_FieldMgr mgr)
        {
            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model, transform);
                cell.add_view(view);
            }
        }
    }
}

