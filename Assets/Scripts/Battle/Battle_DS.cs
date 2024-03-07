using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public struct VID
    {
        public int x;
        public int y;

        //==================================================================================================

        /// <summary>
        /// 边界约束
        /// </summary>
        public static bool border_constraint(ref VID vid)
        {
            ref int x = ref vid.x;
            ref int y = ref vid.y;

            Common_DS.instance.try_get_value(Config.land_area, out (int x, int y) area);
            var mx = area.x - 1;
            var my = area.y - 1;

            x = x < 0 ? 0 : x;
            x = x > mx ? mx : x;
            y = y < 0 ? 0 : y;
            y = y > my ? my : y;

            return true;
        }


        /// <summary>
        /// 出界检定
        /// </summary>
        public static bool valid_offset(VID vid)
        {
            int x = vid.x;
            int y = vid.y;

            Common_DS.instance.try_get_value(Config.land_area, out (int x, int y) area);
            var mx = area.x - 1;
            var my = area.y - 1;

            return !(x < 0 || x > mx || y < 0 || y > my);
        }


        public static explicit operator Vector2(VID v)
        {
            return new()
            {
                x = v.x,
                y = v.y
            };
        }


        public static implicit operator VID(Vector2 v)
        {
            return new()
            {
                x = Mathf.FloorToInt(v.x),
                y = Mathf.FloorToInt(v.y),
            };
        }


        public static implicit operator VID((int x, int y) tuple)
        {
            return new()
            {
                x = tuple.x,
                y = tuple.y,
            };
        }


        public static VID operator +(VID v1, VID v2)
        {
            return new()
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y,
            };
        }


        public static VID operator -(VID v1, VID v2)
        {
            return new()
            {
                x = v1.x - v2.x,
                y = v1.y - v2.y,
            };
        }


        public static bool operator ==(VID v1, VID v2)
        {
            return object.Equals(v1, v2);
        }


        public static bool operator !=(VID v1, VID v2)
        {
            return !object.Equals(v1, v2);
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var vid = (VID)obj;

            var ret = (x == vid.x) && (y == vid.y);
            return ret;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }


        public static VID[] convert(Vector2[] objs, VID offset = default)
        {
            List<VID> ret = new();

            foreach (var obj in objs)
            {
                ret.Add(obj + offset);
            }

            return ret.ToArray();
        }
    }


    public interface IEntityMgr
    {
        IEnumerable<VID> pos_array { get; }
    }


    public interface ISkillMono
    {
        public uint id { get; }
    }


    public interface ISkillMono_Dyn : ISkillMono
    {
        public Dictionary<int, string[]> data { get; }
    }
}

