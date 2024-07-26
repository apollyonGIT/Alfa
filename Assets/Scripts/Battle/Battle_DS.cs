using UnityEngine;

namespace Battle
{
    public struct Hexagon_ID
    {
        public int q, r, s;
        public static Hexagon_ID zero = new();

        //==================================================================================================

        public static Hexagon_ID operator +(Hexagon_ID h1, Hexagon_ID h2)
        {
            h1.q += h2.q;
            h1.r += h2.r;
            h1.s += h2.s;

            return h1;
        }


        public static Hexagon_ID operator -(Hexagon_ID h1, Hexagon_ID h2)
        {
            h1.q -= h2.q;
            h1.r -= h2.r;
            h1.s -= h2.s;

            return h1;
        }


        public Hexagon_ID right(int step = 1)
        {
            var ret = this;
            ret.q += step;
            ret.s -= step;

            return ret;
        }


        public Hexagon_ID right_up(int step = 1)
        {
            var ret = this;
            ret.q += step;
            ret.r -= step;

            return ret;
        }


        public Hexagon_ID right_down(int step = 1)
        {
            var ret = this;
            ret.r += step;
            ret.s -= step;

            return ret;
        }


        public Hexagon_ID left(int step = 1)
        {
            var ret = this;
            ret.s += step;
            ret.q -= step;

            return ret;
        }


        public Hexagon_ID left_up(int step = 1)
        {
            var ret = this;
            ret.s += step;
            ret.r -= step;

            return ret;
        }


        public Hexagon_ID left_down(int step = 1)
        {
            var ret = this;
            ret.r += step;
            ret.q -= step;

            return ret;
        }


        public static implicit operator Vector2(Hexagon_ID id)
        {
            return new();
        }


        public static implicit operator Hexagon_ID(Vector2 v)
        {
            return new();
        }
    }

}

