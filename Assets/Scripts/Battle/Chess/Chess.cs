using Foundation;
using UnityEngine;

namespace Battle.Chesses
{
    public class Chess : Model<Chess, IChessView>
    {
        public VID vid;
        public AutoCode.Tables.Chess.Record _desc;

        public (string, string) info_area_path => _desc.f_info_area;


        public Vector2 view_pos => VID.convert(vid);

        //==================================================================================================

        public Chess(VID vid, uint id)
        {
            this.vid = vid;
            Battle_DB.instance.chess.try_get(id, out _desc);
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

