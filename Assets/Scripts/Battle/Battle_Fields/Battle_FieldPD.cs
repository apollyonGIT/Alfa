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

                view.transform.localPosition = new Vector2(0.5f, 0.5f * Hexagon_Helper.in2out * 1.5f);
            }
        }


        public override void call()
        {
        }


        IEnumerable<Battle_Field> cells(Battle_FieldMgr mgr)
        {
            var id = Hexagon_ID.zero;
            yield return new(mgr, id);

            id = Hexagon_ID.zero.right();
            yield return new(mgr, id);
        }
    }
}

