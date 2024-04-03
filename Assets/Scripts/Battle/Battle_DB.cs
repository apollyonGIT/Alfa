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


        Player m_player;
        public Player player
        {
            get
            {
                if (m_player == null)
                {
                    EX_Utility.try_load_table("player", out m_player);
                }

                return m_player;
            }
        }
    }
}

