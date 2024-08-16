using Battle.BT_Graphs;
using CalcExpr;
using System.Collections.Generic;
using System.Reflection;

namespace Battle.Graph_Module
{
    public class EX_Data
    {
        public static Dictionary<string, string> datas = new();
        public static System.Type owner_type = typeof(BT_Context);

        //================================================================================================

        public static void reset()
        {
            datas.Clear();

            foreach (var pi in owner_type.GetProperties())
            {
                var attr = pi.GetCustomAttribute<ExprConstAttribute>();
                if (attr == null) continue;

                datas.Add(attr.name, pi.Name);
            }

            foreach (var fi in owner_type.GetFields())
            {
                var attr = fi.GetCustomAttribute<ExprConstAttribute>();
                if (attr == null) continue;

                datas.Add(attr.name, fi.Name);
            }
        }


    }
}

