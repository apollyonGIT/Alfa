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


        Card m_card;
        public Card card
        {
            get
            {
                if (m_card == null)
                {
                    EX_Utility.try_load_table("card", out m_card);
                }

                return m_card;
            }
        }
    }
}

