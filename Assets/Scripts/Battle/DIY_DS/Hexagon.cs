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


        public static bool operator ==(Hexagon h1, Hexagon h2)
        {
            return (h1.q == h2.q) && (h1.r == h2.r) && (h1.s == h2.s);
        }


        public static bool operator !=(Hexagon h1, Hexagon h2)
        {
            return (h1.q != h2.q) || (h1.r != h2.r) || (h1.s != h2.s);
        }


        public override bool Equals(object obj)
        {
            if (obj is not Hexagon h2) return false;
            return (q == h2.q) && (r == h2.r) && (s == h2.s);
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override string ToString()
        {
            return $"q:{q},r:{r},s:{s}";
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
            ret.q = -(ret.s + ret.r);

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
            ret.s = -(ret.r + ret.q);

            return ret;
        }


        public Hexagon left_down(int step = 1)
        {
            var ret = this;

            ret.r += step;
            ret.q = -(ret.r + ret.s);

            return ret;
        }


        public static Vector2 hex_2_xy(Hexagon hex)
        {
            var x = Mathf.Floor((hex.q - hex.s) / 2f);
            var y = -hex.r;

            return new(x, y);
        }


        public static Hexagon xy_2_hex(float x, float y)
        {
            Hexagon ret = zero;

            var qs_add = y;

            var qs_sub_1 = x * 2;
            var qs_sub_2 = x * 2 + 1;
            var qs_sub = (qs_sub_1 + qs_add) * 5 % 10 == 0 ? qs_sub_1 : qs_sub_2;

            ret.q = (int)(qs_sub + qs_add) / 2;
            ret.r = -(int)y;
            ret.s = -(ret.q + ret.r);

            return ret;
        }


        public static Hexagon xy_2_hex(Vector2 v)
        {
            return xy_2_hex(v.x, v.y);
        }


        public static Vector2 hex_2_pos(Hexagon hex, float radius)
        {
            float x = (hex.q - hex.s);
            float y = -hex.r;

            x *= radius;
            y *= (1.5f * radius * in2out);

            return new(x, y);
        }


        public static float distance(Hexagon hex_1, Hexagon hex_2)
        {
            var x = Mathf.Abs((hex_1.q - hex_1.s) - (hex_2.q - hex_2.s));
            var y = Mathf.Abs(hex_1.r - hex_2.r);

            return (x + y) / 2f;
        }
    }
}

