using Foundation;
using UnityEngine;

namespace Battle.AttackAreas
{
    public class AttackAreaView : MonoBehaviour, IAttackAreaView
    {
        AttackArea cell;

        //==================================================================================================

        void IModelView<AttackArea>.attach(AttackArea cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
            gameObject.SetActive(false);
        }


        void IModelView<AttackArea>.detach(AttackArea cell)
        {
            this.cell = null;
        }


        void IModelView<AttackArea>.shift(AttackArea old_cell, AttackArea new_cell)
        {
        }
    }
}

