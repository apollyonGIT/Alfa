using Common.Opr_Module;
using Foundation;
using UnityEngine;

namespace Battle.Battle_Ctrls
{
    public class Battle_CtrlView : OprTargetView, IBattle_CtrlView
    {
        Battle_Ctrl cell;

        //==================================================================================================

        void IModelView<Battle_Ctrl>.attach(Battle_Ctrl cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Battle_Ctrl>.detach(Battle_Ctrl cell)
        {
            this.cell = null;
        }


        void IModelView<Battle_Ctrl>.shift(Battle_Ctrl old_cell, Battle_Ctrl new_cell)
        {
        }


        public override void notify_on_click()
        {
            Debug.Log($"x:{cell.vid.x}, y:{cell.vid.y}");
        }
    }
}

