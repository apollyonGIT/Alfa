using Common;
using Common.Opr_Module;
using Foundation;

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
            Mission.instance.try_get_mgr(Config.Battle_CtrlMgr_Name, out Battle_CtrlMgr mgr);
            mgr.do_on_click(cell.vid);
        }
    }
}

