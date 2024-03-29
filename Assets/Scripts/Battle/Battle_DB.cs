using AutoCode.Tables;
using Common;

namespace Battle
{
    public class Battle_DB : Singleton<Battle_DB>
    {
        Monster m_monster;
        public Monster monster
        {
            get
            {
                if (m_monster == null)
                {
                    EX_Utility.try_load_table("monster", out m_monster);
                }

                return m_monster;
            }
        }
    }
}

