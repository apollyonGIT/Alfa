using Foundation;
using Common;
using UnityEngine.EventSystems;

namespace Battle.Selectors
{
    public class SelectorView : View, ISelectorView, IPointerClickHandler
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


        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            cell.on_click();
        }
    }
}

