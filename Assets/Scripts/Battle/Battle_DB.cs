using AutoCode.Tables;
using Common;

namespace Battle
{
    public class Battle_DB : Singleton<Battle_DB>
    {
        Enemy m_enemy;
        public Enemy enemy
        {
            get
            {
                if (m_enemy == null)
                {
                    EX_Utility.try_load_table("enemy", out m_enemy);
                }

                return m_enemy;
            }
        }
    }
}

