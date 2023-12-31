﻿using Common;
using Foundation;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Territorys
{
    public interface ITerritoryView : IModelView<Territory>
    { 
    }


    public class TerritoryMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<VID, Territory> m_cells = new();

        //==================================================================================================

        public TerritoryMgr(string name, params object[] objs)
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


        public void add_cell(Territory cell)
        {
            m_cells.Add(cell.vid, cell);
        }


        bool IMgr.try_get_cell(out object cell, params object[] prms)
        {
            var vid = (VID)prms[0];
            var ret = m_cells.TryGetValue(vid, out var _cell);
            cell = _cell;

            return ret;
        }
    }
}

