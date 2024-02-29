using System.Collections.Generic;
using System;
using System.Linq;

namespace Common.Table_Module
{
    public class Table_Utility
    {
        public static object do_expr(string code, object obj)
        {
            if (code == null || !code.Any()) return default;

            code = code.TrimEnd(')');
            var raws = code.Split('(');

            var method_name = raws[0];
            var mi = obj.GetType().GetMethod(method_name);
            var pi = mi.GetParameters();

            if (!raws[1].Any())
                return mi?.Invoke(obj, null);

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

