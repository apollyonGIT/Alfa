using Foundation;
using UnityEngine;

namespace Battle.Players
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        Player cell;

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

