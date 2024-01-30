using System.Collections.Generic;
using System;

namespace Common.Table_Module
{
    public class Table_Utility
    {
        public static object do_expr(string code, object obj, Type[] types)
        {
            code = code.TrimEnd(')');
            var raws = code.Split('(');

            var method_name = raws[0];

            var raw_args = raws[1].Split(',');
            List<object> args = new();
            for (int i = 0; i < raw_args.Length; i++)
            {
                var e = Convert.ChangeType(raw_args[i], types[i]);
                args.Add(e);
            }

            return obj.GetType().GetMethod(method_name)?.Invoke(obj, args.ToArray());
        }
    }
}

