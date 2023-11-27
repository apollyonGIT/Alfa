using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.MapLands
{
    public class MapLandPD : Producer
    {
        public int limit_x;
        public int limit_y;

        public MapLandView temp_view;

        public override IMgr imgr => mgr;
        MapLandMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.MapLandMgr_Name);

            foreach (var cell in cells())
            {
                mgr.add_cell(cell);

                var view = Instantiate(temp_view, transform);
                cell.add_view(view);
            }

            //计算本体位置，使其居中于镜头
            Vector2 pos = new(limit_x, limit_y);
            transform.localPosition = pos * -0.5f;
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<MapLand> cells()
        {
            for (int y = 0; y < limit_y; y++)
            {
                for (int x = 0; x < limit_x; x++)
                {
                    MapLand cell = new(x, y);

                    yield return cell;
                }
            }
        }
    }
}

