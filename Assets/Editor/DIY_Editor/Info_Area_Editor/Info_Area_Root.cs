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

        public List<Info_Area> cells = new();

        //==================================================================================================

        public override void load_asset()
        {
            clean();

            foreach (var info in asset.attack_area)
            {
                VID vid = new()
                {
                    x = info.x,
                    y = info.y,
                };
                Info_Area cell = new(vid);

                cells.Add(cell);

                var view = Instantiate(model_area_view, area);
                view.area.enabled = true;
                cell.add_view(view);
            }
        }


        protected override void save_asset(Info_Area_Asset asset)
        {
        }


        public override void clean()
        {
            cells.Clear();

            var view = area.GetComponentsInChildren<Info_AreaView>();
            foreach (var e in view)
            {
                DestroyImmediate(e.gameObject);
            }
        }


        public void do_brush(Vector3 pos)
        {
            Debug.Log(pos);
        }
    }
}

