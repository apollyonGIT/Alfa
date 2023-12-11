using Foundation;
using UnityEngine;

namespace Battle.Info_Areas
{
    public class Info_Area : Model<Info_Area, IInfo_AreaView>
    {
        public VID vid;

        public Vector2 view_pos => VID.convert(vid);
        public Color view_color;

        public bool is_enable;
        public Info_Area_Type type;

        public bool is_select_attack_area => is_enable && type == Info_Area_Type.attack_area;

        //==================================================================================================

        public Info_Area(VID vid)
        {
            this.vid = vid;
        }


        public void enable(Info_Area_Type type)
        {
            this.type = type;
            is_enable = true;

            Info_AreaMgr.type_color_dic.TryGetValue(type, out view_color);

            foreach (var view in views)
            {
                view.notify_on_enable(is_enable);
            }
        }


        public void disable()
        {
            type = Info_Area_Type.none;
            is_enable = false;

            foreach (var view in views)
            {
                view.notify_on_enable(is_enable);
            }
        }
    }
}

