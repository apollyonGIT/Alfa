using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Battle_Fields
{
    public class Battle_FieldPD : Producer
    {
        public Battle_FieldView model;

        public override IMgr imgr => mgr;
        Battle_FieldMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("Battle_FieldMgr", priority);

            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model, transform);
                cell.add_view(view);

                view.transform.localPosition = Hexagon.calc_unity_pos(cell.id, 0.5f);
            }
        }


        public override void call()
        {
        }


        IEnumerable<Battle_Field> cells(Battle_FieldMgr mgr)
        {
            Hexagon id;

            id = Hexagon.zero.xy2hex(new(0, 1));
            yield return new(mgr, id);

            id = Hexagon.zero.xy2hex(new(0, 0));
            yield return new(mgr, id);

            id = Hexagon.zero.xy2hex(new(1, 1));
            yield return new(mgr, id);

            id = Hexagon.zero.xy2hex(new(1, 0));
            yield return new(mgr, id);

            id = Hexagon.zero.xy2hex(new(0, 2));
            yield return new(mgr, id);
        }
    }
}

