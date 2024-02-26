using Common;
using Foundation;

namespace Battle.Enemys
{
    public class EnemyView : View, IEnemyView
    {
        Enemy cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Enemy>.attach(Enemy cell)
        {
            this.cell = cell;
        }


        void IModelView<Enemy>.detach(Enemy cell)
        {
            this.cell = null;
        }


        void IEnemyView.notify_on_tick1()
        {
            transform.localPosition = cell.view_pos;
        }
    }
}

