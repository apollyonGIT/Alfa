using Foundation;
using Common;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace Battle.Behaviour_Options
{
    public class Behaviour_OptionView : View, ISelectorView, IPointerClickHandler
    {
        public RawImage bg;

        Behaviour_Option cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Behaviour_Option>.attach(Behaviour_Option cell)
        {
            this.cell = cell;
        }


        void IModelView<Behaviour_Option>.detach(Behaviour_Option cell)
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


        void ISelectorView.notify_on_select()
        {
            bg.color = Color.yellow;
        }


        void ISelectorView.notify_on_cancel()
        {
            bg.color = Color.white;
        }

    }
}

