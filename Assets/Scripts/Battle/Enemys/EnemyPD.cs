using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemys
{
    public class EnemyPD : Producer
    {
        public EnemyView model;

        public override IMgr imgr => mgr;
        EnemyMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("EnemyMgr", priority);

            foreach (var cell in cells())
            {
                mgr.add_cell(cell);

                var view = Instantiate(model, transform);
                cell.add_view(view);
            }
        }


        public override void call()
        {
            mgr.is_call = true;
        }


        IEnumerable<Enemy> cells()
        {
            var id = 400000201u;
            var pos = new Vector2(1, 1);

            yield return new(mgr, id, pos);
        }
    }
}

