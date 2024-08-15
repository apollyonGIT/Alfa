using Foundation;
using UnityEngine;
using TMPro;

namespace Battle.Enemys
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public TextMeshPro _name;

        Enemy cell;

        //==================================================================================================

        void IModelView<Enemy>.attach(Enemy cell)
        {
            this.cell = cell;

            fresh();
        }


        void IModelView<Enemy>.detach(Enemy cell)
        {
            this.cell = null;
        }


        void fresh()
        {
            _name.text = cell._desc.f_name;

            transform.localPosition = cell.view_pos;
        }


        public void notify_on_left_click()
        {
            Debug.Log(123);
        }


        void IEnemyView.notify_on_tick()
        {
            fresh();
        }
    }
}

