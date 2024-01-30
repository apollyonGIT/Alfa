using Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle
{
    public class Chess_Helper : Singleton<Chess_Helper>
    {
        public List<VID> enetity_pos_array => calc_entity_pos_array();

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


        public List<VID> calc_entity_pos_array()
        {
            IEnumerable<VID> r = default;

            foreach (var (_, v) in Mission.instance.mgr_dic)
            {
                if (v is not IEntityMgr mgr) continue;

                if (r == null)
                {
                    r = mgr.pos_array;
                    continue;
                }
                    
                r = r.Concat(mgr.pos_array);
            }

            return r.ToList();
        }
    }
}

