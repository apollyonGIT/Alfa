using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Battle_Fields
{
    public interface IBattle_FieldView : IModelView<Battle_Field>
    { 
    }


    public class Battle_FieldMgr : IMgr
    {
        Dictionary<Hexagon, Battle_Field> cells = new();

        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        //==================================================================================================

        public Battle_FieldMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        public void add_cell(Battle_Field cell)
        {
            cells.Add(cell.id, cell);
        }


        public void remove_cell(Battle_Field cell)
        {
            cells.Remove(cell.id);
        }


        public void remove_cells()
        {
            foreach (var (_, cell) in cells)
            {
                cell.clear_views();
            }

            cells.Clear();
        }
    }
}

