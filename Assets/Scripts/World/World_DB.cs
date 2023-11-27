using AutoCode.Tables;
using Common;

namespace World
{
    public class World_DB : Singleton<World_DB>
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
    }
}

