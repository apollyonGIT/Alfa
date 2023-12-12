using Battle.Info_Areas;
using UnityEngine;

namespace Editor.DIY_Editor.Info_Area_Editor
{
    public class Info_Area_Root : Root<Info_Area_Asset>
    {
        public Transform area;
        public Info_AreaView model_area_view;

        //==================================================================================================

        public override void load_asset()
        {
            clean();

            foreach (var info in asset.attack_area)
            {
                Vector2 pos = new(info.x, info.y);
                var view = Instantiate(model_area_view, area);
                view.transform.localPosition = pos;
                view.area.enabled = true;
            }
        }


        protected override void save_asset(Info_Area_Asset asset)
        {
        }


        public override void clean()
        {
            var view = area.GetComponentsInChildren<Info_AreaView>();
            foreach (var e in view)
            {
                DestroyImmediate(e.gameObject);
            }
        }
    }
}

