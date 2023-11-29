using Common;

namespace Battle.Helpers
{
    public class SquareMap_Helper
    {
        //==================================================================================================

        public static void encode_vid(int x, int y, out int vid)
        {
            vid = 100 * y + x;
        }


        public static void decode_vid(int vid, out int x, out int y)
        {
            x = vid % 100;
            y = (vid - x) / 100;
        }


        static void up(ref int vid, int step)
        {
            decode_vid(vid, out var x, out var y);

            y += step;
            if (y > Config.mapland_limit_y) return;

            encode_vid(x, y, out vid);
        }


        static void down(ref int vid, int step)
        {
            decode_vid(vid, out var x, out var y);

            y -= step;
            if (y < 0) return;

            encode_vid(x, y, out vid);
        }


        static void right(ref int vid, int step)
        {
            decode_vid(vid, out var x, out var y);

            x += step;
            if (x > Config.mapland_limit_x) return;

            encode_vid(x, y, out vid);
        }


        static void left(ref int vid, int step)
        {
            decode_vid(vid, out var x, out var y);

            x -= step;
            if (x < 0) return;

            encode_vid(x, y, out vid);
        }


        public static void move(ref int vid, int step_x, int step_y)
        {
            if (step_x > 0)
                right(ref vid, step_x);

            if (step_x < 0)
                left(ref vid, step_x);

            if (step_y > 0)
                up(ref vid, step_y);

            if (step_y < 0)
                down(ref vid, step_y);
        }
    }
}

