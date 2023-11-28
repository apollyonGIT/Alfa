using Common;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.YamlDotNet.Core.Events;
using UnityEngine;
using World;

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

        LinkedList<HandCard> cells = new();

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
            if (cells.Any())
            {
                seq = cells.Count;
            }
            cell.seq = seq;
            cell.mgr = this;

            cells.AddLast(cell);
        }


        public void remove_cell(HandCard cell)
        {
            var node = cells.Find(cell);
            var last = cells.Last;

            while (node != last)
            {
                node = node.Next;
                var e = node.Value;
                e.seq--;
                e.reset_pos();
            }

            cells.Remove(cell);
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
    }
}

