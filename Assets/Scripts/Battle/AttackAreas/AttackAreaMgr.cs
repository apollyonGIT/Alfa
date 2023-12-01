using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.AttackAreas
{
    public interface IAttackAreaView : IModelView<AttackArea>
    { 
        
    }


    public class AttackAreaMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<int, AttackArea> m_cells = new();

        //==================================================================================================

        public AttackAreaMgr(string name, params object[] objs)
        {
            m_mgr_name = name;
            (this as IMgr).init(objs);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        public void add_cell(AttackArea cell)
        {
            m_cells.Add(cell.vid ,cell);
        }


        public void enable_cell(int vid)
        { 
            
        }


        public void disable_cell(int vid)
        {

        }

    }
}

