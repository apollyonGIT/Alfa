using Common;
using System.Collections.Generic;

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
            }
        }


        public override void call()
        {
        }


        IEnumerable<Battle_Field> cells(Battle_FieldMgr mgr)
        {
            var id = Hexagon_ID.zero;
            yield return new(mgr, id);
        }
    }
}

