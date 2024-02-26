using Common;
using Foundation;

namespace Battle.Players
{
    public class PlayerView : View, IPlayerView
    {
        Player cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Player>.attach(Player cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Player>.detach(Player cell)
        {
            this.cell = null;
        }


        void IPlayerView.notify_on_tick1()
        {
            transform.localPosition = cell.view_pos;
        }
    }
}

