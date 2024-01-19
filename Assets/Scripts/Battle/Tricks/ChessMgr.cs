using UnityEngine;

namespace Battle.Tricks
{
    public class ChessMgr
    {
        public virtual void move(ref VID pos, Vector2 step)
        { 
        }


        public void opti_move(ref VID pos, Vector2 step)
        {
            pos += step;
            VID.border_constraint(ref pos);
        }


        public bool pess_move(ref VID pos, Vector2 step)
        {
            var temp = pos + step;

            if (!VID.valid_offset(temp)) return false;
            pos = temp;
            return true;
        }


        /// <summary>
        /// 尝试获取可抵达范围
        /// </summary>
        public virtual bool try_get_arrivals(VID pos, out VID[] arrival_pos_array)
        {
            arrival_pos_array = default;
            return true;
        }
    }
}

