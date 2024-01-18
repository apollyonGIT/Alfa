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

        Dictionary<VID, Land> m_cells = new();

        //==================================================================================================

        public LandMgr(string name, params object[] objs)
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

