﻿using Common;
using UnityEngine;

namespace Battle
{
    public class Battle_DS : Singleton<Battle_DS>
    {
        
    }


    public struct VID 
    {
        public int x;
        public int y;

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


        public static VID move(VID v, int x_step, int y_step)
        {
            var ret = v;
            v.x += x_step;
            v.y += y_step;

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

