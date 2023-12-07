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
            mission.do_mgr_method(player_mgr, "move", new object[] { vid, 0, 2 });
        }
    }
}

