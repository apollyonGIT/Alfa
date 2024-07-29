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
            ret.s -= step;

            return ret;
        }


        public Hexagon right_up(int step = 1)
        {
            var ret = this;
            ret.q += (step - 1);
            ret.r -= step;

            return ret;
        }


        public Hexagon right_down(int step = 1)
        {
            var ret = this;
            ret.r += step;
            ret.s -= (step - 1);

            return ret;
        }


        public Hexagon left(int step = 1)
        {
            var ret = this;
            ret.s += step;
            ret.q -= step;

            return ret;
        }


        public Hexagon left_up(int step = 1)
        {
            var ret = this;
            ret.s += (step - 1);
            ret.r -= step;

            return ret;
        }


        public Hexagon left_down(int step = 1)
        {
            var ret = this;
            ret.r += step;
            ret.q -= (step - 1);

            return ret;
        }


        public static Vector2 calc_unity_pos (Hexagon hex, float radius)
        {
            var v = hex.hex2xy();
            Debug.Log(v);
            
            var x = 2 * v.x;
            var y = in2out * 1.5f * v.y;
            var ret = new Vector2(x, y);

            if ((v.y % 2) == 0)
                return ret * radius;
            else
                return ret * radius + new Vector2(radius, 0);
        }


        public static implicit operator Hexagon(Vector2 v)
        {
            return new();
        }


        Vector2Int hex2xy()
        {
            var e = r % 2;

            return new(q, -r);
        }


        public Hexagon xy2hex(Vector2Int v)
        {
            var hex = zero;
            hex.r = -v.y;
            hex.q = v.x;
            hex.s = 0 - (hex.r + hex.q);

            return hex;
        }
    }
}

