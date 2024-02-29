using Common.Table_Module;
using Foundation;

namespace Battle.Skills
{
    public class Skill : Model<Skill, ISkillView>
    {
        public string title;
        public string content;
        public int cost;

        public bool is_active => skill_mono != null;
        public bool is_lock;

        public int pos;
        public ISkillMono skill_mono;
        public string cast_func;

        public SkillMgr mgr;

        //==================================================================================================

        public Skill(SkillMgr mgr, params object[] args)
        {
            this.mgr = mgr;
            pos = (int)args[0];

            reset();
        }


        public void load(int cost, string title, string content)
        {
            this.cost = cost;
            this.title = title;
            this.content = content;
        }


        internal void tick()
        {
            
        }


        internal void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }


        public void reset()
        {
            title = "";
            content = "";
            cost = 0;
        }


        public void cast()
        {
            Table_Utility.do_expr(cast_func, skill_mono);
        }
    }
}

