using Common;
using Foundation;
using System.Collections.Generic;
using System.Net;
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


        public void enable_cell(VID vid, Info_Area_Type type, (string, string) asset_path)
        {
            disable_all();

            EX_Utility.try_load_asset(asset_path, out Info_Area_Asset asset);

            foreach (var cell in @select(vid, type, asset))
            {
                cell.enable(type);
            }
        }


        public void add_cell(Info_Area cell)
        {
            m_cells.Add(cell.vid, cell);
        }


        /// <summary>
        /// 根据条件选取cells
        /// </summary>
        IEnumerable<Info_Area> @select(VID vid, Info_Area_Type type, Info_Area_Asset asset)
        {
            var fi = asset.GetType().GetField(type.ToString());
            var infos = (Info_Area_Asset.Info[])fi.GetValue(asset);
            if (infos == null) yield return null;

            foreach (var info in infos)
            {
                var _vid = vid;
                if (!VID.move(ref _vid, info.x, info.y, false)) continue;
                if (!m_cells.TryGetValue(_vid, out var cell)) continue;

                yield return cell;
            }
        }
    }
}

