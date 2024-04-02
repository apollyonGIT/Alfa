using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.SeekPath_Module
{
    public class SeekPath_Utility
    {
        static Vector2[] s_dirs = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        //==================================================================================================

        public struct Node
        {
            public Vector2 pos;
            public Vector2? last_pos;

            public int g;
            public int h;
            public int f => g + h;

            public static int calc_h(Vector2 start, Vector2 end)
            {
                var offset = end - start;
                return (int)(Mathf.Abs(offset.x) + Mathf.Abs(offset.y));
            }


            public Node(Vector2 pos, Vector2? last_pos, int g, Vector2 end)
            {
                this.pos = pos;
                this.last_pos = last_pos;
                this.g = g;
                h = calc_h(pos, end);
            }
        }


        public static bool try_seek_path(Vector2 start, Vector2 end, Vector2[] obstacles, Func<Vector2, bool> valid_in_area_func, out LinkedList<Vector2> ret)
        {
            ret = new LinkedList<Vector2>();

            Node t = new(start, null, 0, end);
            var open = new Dictionary<Vector2, Node>() { { t.pos, t } };
            var close = new Dictionary<Vector2, Node>();
            var focus_list = new LinkedList<Node>();

            while (t.pos != end)
            {
                if (open.ContainsKey(t.pos))
                    open.Remove(t.pos);
                close.Add(t.pos, t);

                focus_list.Clear();
                foreach (var dir in s_dirs)
                {
                    var pos = dir + t.pos;
                    if (obstacles.Contains(pos)) continue;
                    if (!valid_in_area_func.Invoke(pos)) continue;
                    if (close.ContainsKey(pos)) continue;                    

                    Node temp = new(pos, t.pos, t.g + 1, end);
                    if (open.TryGetValue(pos, out var open_node))
                    {
                        if (temp.f < open_node.f)
                            open[pos] = temp;
                    }
                    else
                    {
                        open.Add(pos, temp);
                    }

                    //规则：seek方向乱序
                    if (EX_Utility.rnd_int(0, 1) == 0)
                        focus_list.AddLast(temp);
                    else
                        focus_list.AddFirst(temp);
                }

                //规则：如果不存在open格，代表无法到达
                if (!open.Any())
                {
                    Debug.Log("无法到达");
                    return false;
                }

                open = open.OrderBy(e => e.Value.f).ToDictionary(e => e.Key, e => e.Value);
                t = open.First().Value;

                //优化
                foreach (var f in focus_list)
                {
                    if (f.f == t.f)
                    {
                        t = f;
                        break;
                    }
                }
            }

            //回溯处理
            while (t.pos != start)
            {
                ret.AddFirst(t.pos);
                close.TryGetValue((Vector2)t.last_pos, out t);
            }
            return true;
        }
    }
}

