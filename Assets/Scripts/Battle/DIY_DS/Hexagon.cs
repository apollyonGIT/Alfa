using UnityEngine;

namespace Battle
{
    public struct Hexagon
    {
        public int q, r, s;
        public static Hexagon zero = new();

        public const float in2out = 1.154700538379f;
        public const float out2in = 0.866025403785f;

        //==================================================================================================

        public static Hexagon operator +(Hexagon h1, Hexagon h2)
        {
            h1.q += h2.q;
            h1.r += h2.r;
            h1.s += h2.s;

            return h1;
        }


        public static Hexagon operator -(Hexagon h1, Hexagon h2)
        {
            h1.q -= h2.q;
            h1.r -= h2.r;
            h1.s -= h2.s;

            return h1;
        }


        public Hexagon right(int step = 1)
        {
            var ret = this;
            ret.q += step;
            ret.s = -(ret.q + ret.r);

            return ret;
        }


        public Hexagon right_up(int step = 1)
        {
            var ret = this;
            ret.r -= step;
            ret.s = -(ret.q + ret.r);

            return ret;
        }


        public Hexagon right_down(int step = 1)
        {
            var ret = this;
            ret.r += step;
            ret.s = -(ret.q + ret.r);

            return ret;
        }


        public Hexagon left(int step = 1)
        {
            var ret = this;
            ret.q -= step;
            ret.s = -(ret.q + ret.r);

            return ret;
        }


        public Hexagon left_up(int step = 1)
        {
            var ret = this;
            ret.r -= step;
            ret.q -= step;
            ret.s = -(ret.r + ret.q);

            return ret;
        }


        public Hexagon left_down(int step = 1)
        {
            var ret = this;
            ret.r += step;
            ret.q -= step;
            ret.s = -(ret.r + ret.q);

            return ret;
        }


        public static Vector2 hex_2_unity_pos(Hexagon hex, float radius)
        {
            var v = hex_2_xy(hex);
            return xy_2_unity_pos(v, radius);
        }


        public static Vector2Int hex_2_xy(Hexagon hex)
        {
            return new(hex.q, -hex.r);
        }


        public static Vector2 xy_2_unity_pos (Vector2Int v, float radius)
        {
            var _x = 2f * v.x;
            var _y = in2out * 1.5f * v.y;
            var ret = new Vector2(_x, _y);

            if ((_y % 2) == 0)
                return ret * radius;
            else
                return ret * radius + new Vector2(radius, 0);
        }


        public static Hexagon xy_2_hex(Vector2Int v)
        {
            var hex = zero;
            hex.r = -v.y;
            hex.q = v.x;
            hex.s = 0 - (hex.r + hex.q);

            return hex;
        }


        
    }
}

