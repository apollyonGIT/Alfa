using UnityEngine;

namespace Battle.Tricks
{
    public interface IChess
    {
        void move(ref VID pos, Vector2 step);
    }


    public class Chess_Helper
    {
        public static void opti_move(ref VID pos, Vector2 step)
        {
            pos += step;
            VID.border_constraint(ref pos);
        }


        public static void pess_move(ref VID pos, Vector2 step)
        {
            var temp = pos + step;

            if (!VID.valid_offset(temp)) return;
            pos = temp;
        }
    }
}

