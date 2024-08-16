using UnityEngine;

namespace Battle
{
    public class Move_Helper
    {
        public static Vector2 move(EN_Move_Type move_type, Vector2 ori, int step = 1)
        {
            var ret = typeof(Move_Helper).GetMethod(move_type.ToString())?.Invoke(null, new object[] { ori, step });

            return (Vector2)ret;
        }


        public static Vector2 left(Vector2 ori, int step = 1)
        {
            return ori + (Vector2.left * step);
        }


        public static Vector2 right(Vector2 ori, int step = 1)
        {
            return ori + (Vector2.right * step);
        }


        public static Vector2 up(Vector2 ori, int step = 1)
        {
            return ori + (Vector2.up * step);
        }


        public static Vector2 down(Vector2 ori, int step = 1)
        {
            return ori + (Vector2.down * step);
        }
    }
}

