using System.Collections.Generic;
using System;
using System.Linq;

namespace Common.Table_Module
{
    public class Table_Utility
    {
        public static object[] do_expr(string code, object obj)
        {
            if (code == null || !code.Any()) return default;

            List<object> ret = new();
            var codes = code.Split("&&");
            foreach (var _code in codes)
            {
                code = _code.TrimEnd(')');
                var raws = code.Split('(');

                var method_name = raws[0];
                var mi = obj.GetType().GetMethod(method_name);
                var pi = mi.GetParameters();

                if (!raws[1].Any())
                {
                    ret.Add(mi?.Invoke(obj, null));
                    continue;
                } 

                var raw_args = raws[1].Split(',');
                List<object> args = new();
                for (int i = 0; i < raw_args.Length; i++)
                {
                    var e = Convert.ChangeType(raw_args[i], pi[i].ParameterType);
                    args.Add(e);
                }

                ret.Add(mi?.Invoke(obj, args.ToArray()));
            }

            return ret.ToArray();
        }
    }
}

