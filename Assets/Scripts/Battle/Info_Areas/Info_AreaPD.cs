using Common;
using System.Collections.Generic;

namespace Battle.Info_Areas
{
    public class Info_AreaPD : Producer
    {
        public Info_AreaView model_view;

        public override IMgr imgr => mgr;
        Info_AreaMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.InfoAreaMgr_Name);

            var mx = Config.map_max_x;
            var my = Config.map_max_y;

            foreach (var cell in cells(mx, my))
            {
                mgr.add_cell(cell);
                var view = Instantiate(model_view, transform);
                cell.add_view(view);
            }
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Info_Area> cells(int mx, int my)
        {
            for (int y = 0; y < my; y++)
            {
                for (int x = 0; x < mx; x++)
                {
                    var vid = VID.init(x, y);
                    yield return new(vid);
                }
            }
        }
    }
}

