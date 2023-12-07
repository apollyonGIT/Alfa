using Common;
using System.Collections.Generic;

namespace Battle.Battle_Ctrls
{
    public class Battle_CtrlPD : Producer
    {
        public Battle_CtrlView model_view;

        public override IMgr imgr => mgr;
        Battle_CtrlMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.Battle_CtrlMgr_Name);

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


        IEnumerable<Battle_Ctrl> cells(int mx, int my)
        {
            for (int y = 0; y < my; y++)
            {
                for (int x = 0; x < mx; x++)
                {
                    Battle_Ctrl cell = new()
                    {
                        vid = VID.init(x, y)
                    };

                    yield return cell;
                }
            }
        }
    }
}

