﻿using Foundation;

namespace Battle.Talisman_Skills
{
    public class Talisman_Skill : Model<Talisman_Skill, ITalisman_SkillView>
    {
        public bool is_selected;

        public Talisman_SkillMgr mgr;

        //==================================================================================================

        public Talisman_Skill(Talisman_SkillMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }


        public void destroy()
        {
            mgr = null;

            foreach (var view in views)
            {
                view.detach(this);
            }
        }
    }
}
