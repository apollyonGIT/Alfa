using Common;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using World;

namespace Battle.HandCards
{
    public interface IHandCardView : IModelView<HandCard>
    {
        void notify_on_tick1();
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

            var ctx = WorldContext.instance;
            ctx.remove_tick(Config.HandCardMgr_Name);
            ctx.remove_tick1(Config.HandCardMgr_Name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            var ctx = WorldContext.instance;
            ctx.add_tick(Config.HandCardMgr_Priority, Config.HandCardMgr_Name, tick);
            ctx.add_tick1(Config.HandCardMgr_Priority, Config.HandCardMgr_Name, tick1);
        }


        void tick()
        {
            
        }


        void tick1()
        {
            foreach (var cell in cells)
            {
                foreach (var view in cell.views)
                {
                    view.notify_on_tick1();
                }
            }
        }


        public void add_cell(HandCard cell)
        {
            int seq = 0;
            if (cells.Any())
            {
                seq = cells.Count;
            }

            cell.seq = seq;

            cells.AddLast(cell);
        }
    }
}

