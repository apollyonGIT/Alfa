using Foundation;
using UnityEngine;

namespace Battle.Chess
{
    public class Chess : Model<Chess, IChessView>
    {
        public VID vid;

        public Vector2 view_pos => VID.convert(vid);

        //==================================================================================================

        public Chess(VID vid)
        {
            this.vid = vid;
        }


        public void tick()
        {
            
        }


        public void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }
    }
}

