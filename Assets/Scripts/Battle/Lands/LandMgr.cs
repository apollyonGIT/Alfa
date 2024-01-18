using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Lands
{
    public interface ILandView : IModelView<Land>
    { 
    }


    public class LandMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<VID, Land> m_cells = new();

        //==================================================================================================

        public LandMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        bool IMgr.try_get_cell(out object cell, params object[] prms)
        {
            var pos = (VID)prms[0];
            var ret = m_cells.TryGetValue(pos, out var _cell);
            cell = _cell;

            return ret;
        }


        public void add_cell(Land cell)
        {
            m_cells.Add(cell.pos ,cell);
        }
    }
}

