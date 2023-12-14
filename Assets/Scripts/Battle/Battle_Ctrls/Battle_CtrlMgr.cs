using Common;
using Foundation;
using System.Collections.Generic;
using UnityEngine;

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
            var bctx = BattleContext.instance;
            ref var selected_chess_vid = ref bctx.selected_chess_vid;

            var mission = Mission.instance;
            mission.try_get_mgr(Config.ChessMgr_Player_Name, out var player_mgr);
            mission.try_get_mgr(Config.InfoAreaMgr_Name, out var info_area_mgr);
            mission.try_get_mgr(Config.Desc_ContentMgr_Name, out var desc_content_mgr);

            //计算valid
            bool is_player = player_mgr.try_get_cell(out var player_cell, new object[] { vid });

            info_area_mgr.try_get_cell(out var info_area_cell, new object[] { vid });
            mission.try_get_cell_prop(info_area_cell, "is_select_attack_area", out bool is_attack_area);

            //规则：清空
            mission.do_mgr_method(info_area_mgr, "disable_all", null);
            mission.do_mgr_method(desc_content_mgr, "enable_cell", new object[] { false });

            //规则：空点
            if (!is_attack_area && !is_player)
            {
                return;
            }

            //规则：选中chess
            if (!is_attack_area && is_player)
            {
                if (bctx.energy == 0) return;

                selected_chess_vid = vid;

                //显示攻击范围
                if (!mission.try_get_cell_prop(player_cell, "info_area_path", out (string, string) info_area_path)) return;
                mission.do_mgr_method(info_area_mgr, "enable_cell", new object[] { vid, Info_Area_Type.attack_area, info_area_path });

                //显示详情
                mission.do_mgr_method(desc_content_mgr, "enable_cell", new object[] { true });

                return;
            }

            //规则：选中攻击范围
            if (is_attack_area && !is_player)
            {
                mission.do_mgr_overload_method(player_mgr, "move", new object[] { selected_chess_vid, vid });
                selected_chess_vid = vid;
                mission.do_mgr_method(info_area_mgr, "disable_all", null);

                bctx.energy--;

                return;
            }

            //规则：范围内交互
            if (is_attack_area && is_player)
            {
                Debug.Log("存在目标");
                return;
            }

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

