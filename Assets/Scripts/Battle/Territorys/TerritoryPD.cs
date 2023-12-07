using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Territorys
{
    public class TerritoryPD : Producer
    {
        public TerritoryView temp_view;

        public override IMgr imgr => mgr;
        TerritoryMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.TerritoryMgr_Name);

            foreach (var cell in cells())
            {
                mgr.add_cell(cell);

                var view = Instantiate(temp_view, transform);
                cell.add_view(view);
            }

            //计算mono位置，使其居中于镜头
            Vector2 pos = new(Config.map_max_x, Config.map_max_y);
            BattleSceneRoot.instance.monoRoot.localPosition = pos * -0.5f;
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Territory> cells()
        {
            var mx = Config.map_max_x;
            var my = Config.map_max_y;

            for (int y = 0; y < my; y++)
            {
                for (int x = 0; x < mx; x++)
                {
                    Territory cell = new()
                    {
                        vid = VID.init(x, y)
                    };

                    yield return cell;
                }
            }
        }
    }
}

