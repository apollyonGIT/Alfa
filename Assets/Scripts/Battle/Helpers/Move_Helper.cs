using UnityEngine;

namespace Battle
{
    public class Move_Helper
    {
        public static void left(ref Vector2 ori, int step = 1)
        {
            ori += (Vector2.left * step);
        }


        public static void right(ref Vector2 ori, int step = 1)
        {
            ori += (Vector2.right * step);
        }


        public static void up(ref Vector2 ori, int step = 1)
        {
            ori += (Vector2.up * step);
        }


        public static void down(ref Vector2 ori, int step = 1)
        {
            ori += (Vector2.down * step);
        }
    }
}

