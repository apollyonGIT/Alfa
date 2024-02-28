using Foundation;

namespace Battle.Skills
{
    public class Skill : Model<Skill, ISkillView>
    {
        public SkillMgr mgr;

        //==================================================================================================

        public Skill(SkillMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }
    }
}

