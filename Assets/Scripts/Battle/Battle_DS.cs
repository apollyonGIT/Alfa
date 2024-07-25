using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    }

}

