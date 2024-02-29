using Foundation;
using System;

namespace Battle.Skills
{
    public class Skill : Model<Skill, ISkillView>
    {
        public string content;

        public int id;
        public SkillMgr mgr;

        //==================================================================================================

        public Skill(SkillMgr mgr, params object[] args)
        {
            this.mgr = mgr;
            id = (int)args[0];

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
    }
}

