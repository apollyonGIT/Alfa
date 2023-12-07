using AutoCode.Tables;
using Common;

namespace Battle
{
    public class Battle_DB : Singleton<Battle_DB>
    {
        Card m_card;
        uint[] m_card_id_pool;

        public Card card
        {
            get
            {
                if (m_card == null)
                {
                    EX_Utility.try_load_table("card", out m_card);
                }

                var rs = m_card.records;
                m_card_id_pool = new uint[rs.Count];

                int i = 0;
                foreach (var r in rs)
                {
                    m_card_id_pool[i] = r.f_id;
                    i++;
                }

                return m_card;
            }
        }

        public uint[] card_id_pool
        {
            get
            {
                if (m_card_id_pool == null)
                    _ = card;
                    
                return m_card_id_pool;
            }
        }

    }
}

