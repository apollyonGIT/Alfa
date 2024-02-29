using AutoCode.Tables;
using Common;

namespace Battle
{
    public class Battle_DB : Singleton<Battle_DB>
    {
        Element m_element;
        public Element element
        {
            get
            {
                if (m_element == null)
                {
                    EX_Utility.try_load_table("element", out m_element);
                }

                return m_element;
            }
        }


        Trigram m_trigram;
        public Trigram trigram
        {
            get
            {
                if (m_trigram == null)
                {
                    EX_Utility.try_load_table("trigram", out m_trigram);
                }

                return m_trigram;
            }
        }


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


        BehaviourOption m_behaviour_option;
        public BehaviourOption behaviour_option
        {
            get
            {
                if (m_behaviour_option == null)
                {
                    EX_Utility.try_load_table("behaviour_option", out m_behaviour_option);
                }

                return m_behaviour_option;
            }
        }
    }
}

