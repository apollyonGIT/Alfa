using Common;
using Foundation;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Info_Areas
{
    public interface IInfo_AreaView : IModelView<Info_Area>
    {
        void notify_on_change();
        void notify_on_enable(bool is_enable);
    }


    public class Info_AreaMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<VID, Info_Area> m_cells = new();

        public static Dictionary<Info_Area_Type, Color> type_color_dic = new()
        {
            { Info_Area_Type.none, new(0,0,0,0) },
            { Info_Area_Type.attack_area, Config.current.player_attack_area_color },
        };

        //==================================================================================================

        public Info_AreaMgr(string name, params object[] objs)
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


        public void disable_all()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.disable();
            }
        }


        public void enable_cell(VID vid, Info_Area_Type type)
        {
            disable_all();

            

            if (!m_cells.TryGetValue(vid, out var cell)) return;



            cell.enable(type);
        }


        public void add_cell(Info_Area cell)
        {
            m_cells.Add(cell.vid, cell);
        }


        /// <summary>
        /// 根据条件选取cells
        /// </summary>
        bool @select(VID vid, Info_Area_Type type, out Queue<Info_AreaMgr> cells)
        {
            cells = new();

            //Mission.instance.do_mgr_method(Config.ChessMgr_Player_Name, "");

            //if (type == Info_Area_Type.attack_area)
            //{ 
                
            //}

            return true;
        }
    }
}

