using Battle.Info_Areas;
using Common;
using System.Collections.Generic;

namespace Battle.Battle_Ctrls
{
    public class Battle_CtrlPD : Producer
    {
        public Battle_CtrlView model_view;

        public override IMgr imgr => mgr;

        Battle_CtrlMgr mgr;
        Info_AreaMgr info_area_mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.Battle_CtrlMgr_Name);
            info_area_mgr = new(Config.InfoAreaMgr_Name);
            
            var mx = Config.map_max_x;
            var my = Config.map_max_y;

            foreach (var (cell, info_area_cell) in cells(mx, my))
            {
                mgr.add_cell(cell);
                var view = Instantiate(model_view, transform);
                cell.add_view(view);

                info_area_mgr.add_cell(info_area_cell);
                var info_area_view = view.transform.GetComponentInChildren<Info_AreaView>();
                info_area_cell.add_view(info_area_view);
            }
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<(Battle_Ctrl cell, Info_Area info_area_cell)> cells(int mx, int my)
        {
            for (int y = 0; y < my; y++)
            {
                for (int x = 0; x < mx; x++)
                {
                    var vid = VID.init(x, y);

                    Battle_Ctrl cell = new(vid);
                    Info_Area info_area_cell = new(vid);

                    yield return (cell, info_area_cell);
                }
            }
        }
    }
}

