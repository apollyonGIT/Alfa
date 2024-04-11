using Common;
using Common.Ticker_Module;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        public Vector2 temp_cell_pos_for_test => (Vector2)m_cells.First().Value.pos;

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


        public void move_by_step(Enemy cell, Vector2 step)
        {
            ref var pos = ref cell.pos;
            var from = pos;
            Entity_Helper.move_by_step(ref pos, step);

            remove_cell(from);
            add_cell(cell);
        }


        public void move_to_pos(Enemy cell, Vector2 new_pos)
        {
            var step = new_pos - (Vector2)cell.pos;
            move_by_step(cell, step);        
        }


        public void move_to_player()
        {
            var ctx = BattleContext.instance;

            var temp = m_cells.ToList();
            foreach (var (_, cell) in temp)
            {
                var start = cell.pos;
                var end = ctx.pos;

                if (SeekPath_Helper.try_seek_path(start, end, new(), VID.valid_in_area, out var paths))
                {
                    var pos = paths.First();

                    if (pos != ctx.pos)
                        move_to_pos(cell, pos);
                    else
                        collide_with_player(ctx, cell);
                }  
            }
        }


        public void collide_with_player(BattleContext ctx, Enemy cell)
        {
            ref int player_hp = ref ctx.hp;
            player_hp -= 10;
        }
    }
}

