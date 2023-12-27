using Common;
using UnityEngine;

namespace Battle
{
    public struct VID
    {
        public int x;
        public int y;

        //==================================================================================================

        public static bool safe_offset(ref VID vid)
        {
            ref int x = ref vid.x;
            ref int y = ref vid.y;

            Common_DS.instance.try_get_value(Config.bf_land_area, out (int x, int y) area);
            var mx = area.x - 1;
            var my = area.y - 1;

            x = x < 0 ? 0 : x;
            x = x > mx ? mx : x;
            y = y < 0 ? 0 : y;
            y = y > my ? my : y;

            return true;
        }


        public static bool unsafe_offset(VID vid)
        {
            int x = vid.x;
            int y = vid.y;

            Common_DS.instance.try_get_value(Config.bf_land_area, out (int x, int y) area);
            var mx = area.x - 1;
            var my = area.y - 1;

            return !(x < 0 || x > mx || y < 0 || y > my);
        }


        public static bool move(ref VID v, int step_x, int step_y, bool is_safe_mode = true)
        {
            v.x += step_x;
            v.y += step_y;

            if (is_safe_mode)
                return safe_offset(ref v);
            else
                return unsafe_offset(v);
        }


        public static VID init(int x, int y)
        {
            var ret = new VID
            {
                x = x,
                y = y
            };

            safe_offset(ref ret);
            return ret;
        }


        public static Vector2 convert(VID v)
        {
            Vector2 ret = new()
            {
                x = v.x,
                y = v.y
            };

            return ret;
        }
    }
}

