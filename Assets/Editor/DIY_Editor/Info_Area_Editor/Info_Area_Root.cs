using Battle;
using Battle.Info_Areas;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.DIY_Editor.Info_Area_Editor
{
    public class Info_Area_Root : Root<Info_Area_Asset>
    {
        public Transform area;
        public Info_AreaView model_area_view;

        Dictionary<VID, Info_Area> m_cells = new();

        //==================================================================================================

        public override void load_asset()
        {
            clean();

            foreach (var info in asset.attack_area)
            {
                add_attack_area(info.x, info.y);
            }
        }


        protected override void save_asset(Info_Area_Asset asset)
        {
        }


        public override void clean()
        {
            m_cells.Clear();

            var view = area.GetComponentsInChildren<Info_AreaView>();
            foreach (var e in view)
            {
                DestroyImmediate(e.gameObject);
            }
        }


        public void do_brush(Vector3 pos)
        {
            int x = Mathf.FloorToInt(pos.x);
            int y = Mathf.FloorToInt(pos.y);

            add_attack_area(x, y);
        }


        public void do_erase(Vector3 pos)
        {
            int x = Mathf.FloorToInt(pos.x);
            int y = Mathf.FloorToInt(pos.y);

            del_attack_area(x, y);
        }


        void add_attack_area(int x, int y)
        {
            VID vid = new()
            {
                x = x,
                y = y,
            };
            Info_Area cell = new(vid);

            if (m_cells.ContainsKey(vid)) return;
            m_cells.Add(vid, cell);

            var view = Instantiate(model_area_view, area);
            view.area.enabled = true;
            cell.add_view(view);
        }


        void del_attack_area(int x, int y)
        {
            VID vid = new()
            {
                x = x,
                y = y,
            };

            if (!m_cells.TryGetValue(vid, out var cell)) return;
            m_cells.Remove(vid);

            cell.clear_views();
        }
    }
}

