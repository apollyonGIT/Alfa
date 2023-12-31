﻿using Common;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace Battle.HandCards
{
    public interface IHandCardView : IModelView<HandCard>
    {
        void notify_on_reset_pos();
    }


    public class HandCardMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        LinkedList<HandCard> m_cells = new();

        //==================================================================================================

        public HandCardMgr(string name, params object[] objs)
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


        public void add_cell(HandCard cell)
        {
            int seq = 0;
            if (m_cells.Any())
            {
                seq = m_cells.Count;
            }
            cell.seq = seq;

            m_cells.AddLast(cell);
        }


        public void remove_cell(HandCard cell)
        {
            var node = m_cells.Find(cell);
            var last = m_cells.Last;

            while (node != last)
            {
                node = node.Next;
                var e = node.Value;
                e.seq--;
                e.reset_pos();
            }

            m_cells.Remove(cell);
            cell.clear_views();
        }


        /// <summary>
        /// 出牌
        /// </summary>
        public void play(HandCard cell)
        {
            cell.use_func?.@do();

            //规则：打出后，删除自身
            remove_cell(cell);
        }


        bool IMgr.try_get_cell(out object cell, params object[] prms)
        {
            cell = null;
            return false;
        }
    }
}

