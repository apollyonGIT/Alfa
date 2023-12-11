using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Battle_Ctrls
{
    public interface IBattle_CtrlView : IModelView<Battle_Ctrl>
    {
    }


    public class Battle_CtrlMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<VID, Battle_Ctrl> m_cells = new();

        //==================================================================================================

        public Battle_CtrlMgr(string name, params object[] objs)
        {
            m_mgr_name = name;
            (this as IMgr).init(objs);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        public void add_cell(Battle_Ctrl cell)
        {
            m_cells.Add(cell.vid, cell);
        }


        public void do_on_click(VID vid)
        {
            var mission = Mission.instance;
            mission.try_get_mgr(Config.ChessMgr_Player_Name, out var player_mgr);
            mission.try_get_mgr(Config.InfoAreaMgr_Name, out var info_area_mgr);

            //规则：首先清空所有范围显示
            mission.do_mgr_method(info_area_mgr, "disable_all", new object[] { });

            //规则：如果选中player chess，显示攻击范围
            if (mission.try_get_cell_prop(player_mgr, "info_area_path", out (string, string) info_area_path, new object[] { vid }))
                mission.do_mgr_method(info_area_mgr, "enable_cell", new object[] { vid, Info_Area_Type.attack_area, info_area_path });
        }


        bool IMgr.try_get_cell(out object cell, params object[] prms)
        {
            var vid = (VID)prms[0];
            var ret = m_cells.TryGetValue(vid, out var _cell);
            cell = _cell;

            return ret;
        }
    }
}

