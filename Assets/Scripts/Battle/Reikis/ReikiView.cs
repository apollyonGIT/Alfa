using Foundation;
using Common;
using TMPro;

namespace Battle.Reikis
{
    public class ReikiView : View, IReikiView
    {
        public TextMeshProUGUI turn_reiki;

        ReikiMgr mgr;

        public override object vmgr => mgr;
        public override object vcell => null;

        //==================================================================================================

        void IModelView<ReikiMgr>.attach(ReikiMgr mgr)
        {
            this.mgr = mgr;
        }


        void IModelView<ReikiMgr>.detach(ReikiMgr mgr)
        {
            this.mgr = null;
        }


        void IReikiView.notify_on_tick1()
        {
            turn_reiki.text = $"{BattleContext.instance.reiki_each_turn}";
        }
    }
}

