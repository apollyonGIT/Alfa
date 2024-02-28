using Foundation;
using Common;

namespace Battle.Selectors
{
    public class SelectorView : View, ISelectorView
    {
        Selector cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Selector>.attach(Selector cell)
        {
            this.cell = cell;
        }


        void IModelView<Selector>.detach(Selector cell)
        {
            this.cell = null;
        }


        void ISelectorView.notify_on_tick1()
        {
        }
    }
}

