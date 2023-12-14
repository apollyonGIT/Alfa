using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Store_Checks
{
    public interface IStore_CheckView : IModelView<Store_Check>
    { 
    }


    public class Store_CheckMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<VID, Store_Check> m_cells = new();

        //==================================================================================================

        public Store_CheckMgr(string name, params object[] objs)
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
            cell = null;
            var vid = (VID)prms[0];

            if (!m_cells.TryGetValue(vid, out var _cell)) return false;
            
            cell = _cell;
            return true;
        }


        public void add_cell(Store_Check cell)
        {
            m_cells.Add(cell.vid, cell);
        }

    }
}

