using Foundation;
using UnityEngine;

namespace Battle.Info_Areas
{
    public class Info_Area : Model<Info_Area, IInfo_AreaView>
    {
        public VID vid;

        public Vector2 view_pos => VID.convert(vid);
        public Color view_color;


        //==================================================================================================

        public Info_Area(VID vid)
        {
            this.vid = vid;
        }


        public void enable(Info_Area_Type type)
        {
            Info_AreaMgr.type_color_dic.TryGetValue(type, out view_color);

            foreach (var view in views)
            {
                view.notify_on_enable(true);
            }
        }


        public void disable()
        {
            foreach (var view in views)
            {
                view.notify_on_enable(false);
            }
        }
    }
}

