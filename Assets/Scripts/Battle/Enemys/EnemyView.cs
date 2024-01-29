using Foundation;
using UnityEngine;

namespace Battle.Enemys
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        Enemy cell;

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

