using Common.Table_Module;
using Foundation;

namespace Battle.Skills
{
    public class Skill : Model<Skill, ISkillView>
    {
        public string content;

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


        public void load(string content)
        {
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
            content = "";
        }


        public void cast()
        {
            Table_Utility.do_expr(cast_func, skill_mono);
        }
    }
}

