using Common;
using Common.Ticker_Module;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Foundation.Net.TcpStream;
using static UnityEditor.PlayerSettings;

namespace Battle.Enemys
{
    public interface IEnemyView : IModelView<Enemy>
    {
        void notify_on_tick1();
    }


    public class EnemyMgr : IMgr, IEntityMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        IEnumerable<VID> IEntityMgr.pos_array => EX_Utility.convert_dic_to_ienum(m_cells);

        Dictionary<VID, Enemy> m_cells = new();

        //==================================================================================================

        public EnemyMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);

            var ticker = Ticker.instance;
            {
                ticker.remove_tick(m_mgr_name);
                ticker.remove_tick1(m_mgr_name);
            }
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            var ticker = Ticker.instance;
            {
                ticker.add_tick(m_mgr_priority, m_mgr_name, tick);
                ticker.add_tick1(m_mgr_priority, m_mgr_name, tick1);
            }
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            cell = default;

            var pos = (VID)args[0];
            if (!m_cells.TryGetValue(pos, out var _cell)) return false;

            cell = _cell;
            return true;
        }


        void tick()
        {

        }


        void tick1()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick1();
            }
        }


        public void add_cell(Enemy cell)
        {
            m_cells.Add(cell.pos, cell);
        }


        public void remove_cell(VID pos)
        {
            m_cells.Remove(pos);
        }


        public void move_to(VID to)
        {
            VID pos = (VID)BattleContext.instance.foucs_pos;
            if (!m_cells.TryGetValue(pos, out var cell)) return;

            cell.pos = to;

            remove_cell(pos);
            add_cell(cell);
        }


        public void move(Enemy cell, Vector2 step)
        {
            ref var pos = ref cell.pos;
            var from = pos;
            Chess_Helper.opti_move(ref pos, step);

            remove_cell(from);
            add_cell(cell);
        }


        public void move()
        {
            var temp = m_cells.ToList();
            foreach (var (_, cell) in temp)
            {
                move(cell, new(0, -1));
            }
        }


        public struct Node
        {
            public VID pos;
            public VID? last_pos;

            public int g;
            public int h;
            public int f => g + h;

            public static int calc_h(VID start, VID end)
            {
                var offset = end - start;
                return Mathf.Abs(offset.x) + Mathf.Abs(offset.y);
            }


            public Node(VID pos, VID? last_pos, int g, VID end)
            {
                this.pos = pos;
                this.last_pos = last_pos;
                this.g = g;
                h = calc_h(pos, end);
            }
        }


        public void seek_path(VID[] o, out LinkedList<VID> ret)
        {
            ret = new();

            var start = m_cells.First().Value.pos;
            var end = (0, 0);
            Node t = new(start, null, 0, end);

            var s_dirs = new VID[] { (0, 1), (0, -1), (1, 0), (-1, 0)};
            var open = new Dictionary<VID, Node>() { { t.pos, t } };
            var close = new Dictionary<VID, Node>();
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
                    if (o.Contains(pos)) continue;
                    if (!VID.valid_in_area(pos)) continue;
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
                    return;
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
                close.TryGetValue((VID)t.last_pos, out t);
            }
        }


        public void show_path()
        {
            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr land_mgr);

            var o = new VID[] { (7, 5), (6, 6), (7, 7), (8, 4), (2, 0), (0, 1)};
            seek_path(o, out var ret);
            foreach (var pos in ret)
            {
                land_mgr.set_cell_color(pos, Color.gray);
            }

            foreach (var pos in o)
            {
                land_mgr.set_cell_color(pos, Color.red);
            }
            
        }
    }
}

