using Common;
using System.Collections.Generic;

namespace Battle.Enemys
{
    public class EnemyPD : Producer
    {
        public EnemyView model_view;

        public override IMgr imgr => mgr;
        EnemyMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("EnemyMgr", priority);

            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_view, transform);
                cell.add_view(view);
            }
        }


        public override void call()
        {
            //规则：怪物向下移动一格
            mgr.be_call();
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Enemy> cells(EnemyMgr mgr)
        {
            VID pos = (7, 6);

            yield return new(mgr, pos);
        }
    }
}

