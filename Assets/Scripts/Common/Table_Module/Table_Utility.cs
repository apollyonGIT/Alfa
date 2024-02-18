using System.Collections.Generic;
using System;

namespace Common.Table_Module
{
    public class Table_Utility
    {
        public static object do_expr(string code, object obj)
        {
            code = code.TrimEnd(')');
            var raws = code.Split('(');

            var method_name = raws[0];
            var mi = obj.GetType().GetMethod(method_name);
            var pi = mi.GetParameters();

            var raw_args = raws[1].Split(',');
            List<object> args = new();
            for (int i = 0; i < raw_args.Length; i++)
            {
                var e = Convert.ChangeType(raw_args[i], pi[i].ParameterType);
                args.Add(e);
            }

            return mi?.Invoke(obj, args.ToArray());
        }
    }
}

