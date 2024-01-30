using Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle
{
    public class Chess_Helper : Singleton<Chess_Helper>
    {
        public IEnumerable<VID> enetity_pos_array => calc_entity_pos_array();

        //==================================================================================================

        public static void opti_move(ref VID pos, Vector2 step)
        {
            pos += step;
            VID.border_constraint(ref pos);
        }


        public static bool pess_move(ref VID pos, Vector2 step)
        {
            var temp = pos + step;

            if (!VID.valid_offset(temp)) return false;
            pos = temp;
            return true;
        }


        public IEnumerable<VID> calc_entity_pos_array()
        {
            IEnumerable<VID> r = new List<VID>();

            foreach (var (_, v) in Mission.instance.mgr_dic)
            {
                if (v is not IEntityMgr mgr) continue;                    
                r = r.Concat(mgr.pos_array);
            }

            return r;
        }


        /// <summary>
        /// 阻挡运算，用于处理移动/攻击范围
        /// </summary>
        public void calc_with_block(VID self, ref VID[] area)
        {
            List<VID> ret = area.ToList();

            foreach (var block in enetity_pos_array)
            {
                if (block == self) continue;

                if (block.x == self.x && block.y > self.y)
                {
                    ret.RemoveAll(t => (t.x == block.x && t.y > block.y));
                    continue;
                }

                if (block.x == self.x && block.y < self.y)
                {
                    ret.RemoveAll(t => (t.x == block.x && t.y < block.y));
                    continue;
                }

                if (block.y == self.y && block.x > self.x)
                {
                    ret.RemoveAll(t => (t.y == block.y && t.x > block.x));
                    continue;
                }

                if (block.y == self.y && block.x < self.x)
                {
                    ret.RemoveAll(t => (t.y == block.y && t.x < block.x));
                    continue;
                }
            }

            area = ret.ToArray();
        }
    }
}

