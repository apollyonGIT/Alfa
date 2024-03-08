using Common;
using Common.Table_Module;
using Common.Ticker_Module;
using Foundation;
using System.Collections.Generic;
using static AutoCode.Tables.Skill;

namespace Battle.Skills
{
    public interface ISkillView : IModelView<Skill>
    { 
        void notify_on_tick1();
    }


    public class SkillMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<int, Skill> m_cells = new();
        Dictionary<uint, Record> m_infos = new();

        public bool is_casting;

        //==================================================================================================

        public SkillMgr(string name, int priority, params object[] args)
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
                ticker.add_tick(m_mgr_priority, m_mgr_name, tick1);
            }

            foreach (var r in Battle_DB.instance.skill.records)
            {
                m_infos.Add(r.f_id, r);
            }
        }


        void tick()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick();
            }
        }


        void tick1()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick1();
            }
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            var id = (int)args[0];
            var ret = m_cells.TryGetValue(id, out var _cell);
            cell = _cell;
            return ret;
        }


        public void add_cell(Skill cell)
        {
            m_cells.Add(cell.pos, cell);
        }


        public void reset()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.reset();
            }
        }


        public void load(ISkillMono skill_mono)
        {
            reset();

            if (!m_infos.TryGetValue(skill_mono.id, out var r)) return;

            foreach (var (pos, code) in r.f_load_funcs)
            {
                m_cells.TryGetValue(pos, out var cell);
                Table_Utility.do_expr(code, cell);

                cell.skill_mono = skill_mono;
                r.f_cast_funcs.try_get_value(pos, out cell.cast_func);
            }
        }
    }
}

