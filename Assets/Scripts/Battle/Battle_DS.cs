using Common;
using UnityEngine;

namespace Battle
{
    public class Battle_DS : Singleton<Battle_DS>
    {
        
    }


    public struct VID 
    {
        int x;
        int y;

        //==================================================================================================

        public static void safe_offset(ref VID vid)
        {
            ref int x = ref vid.x;
            ref int y = ref vid.y;

            var mx = Config.map_max_x;
            var my = Config.map_max_y;

            x = x < 0 ? 0 : x;
            x = x > mx ? mx : x;
            y = y < 0 ? 0 : y;
            y = y > my ? my : y;
        }


        public static VID operator +(VID v1, VID v2)
        {
            var ret = v1;
            ret.x += v2.x;
            ret.y += v2.y;

            safe_offset(ref ret);
            return ret;
        }


        public static VID operator -(VID v1, VID v2)
        {
            var ret = v1;
            ret.x -= v2.x;
            ret.y -= v2.y;

            safe_offset(ref ret);
            return ret;
        }


        public static VID right(VID v)
        {
            var ret = v;
            v.x++;

            safe_offset(ref ret);
            return ret;
        }


        public static VID left(VID v)
        {
            var ret = v;
            v.x--;

            safe_offset(ref ret);
            return ret;
        }


        public static VID up(VID v)
        {
            var ret = v;
            v.y++;

            safe_offset(ref ret);
            return ret;
        }


        public static VID down(VID v)
        {
            var ret = v;
            v.y--;

            safe_offset(ref ret);
            return ret;
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

