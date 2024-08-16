using CalcExpr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Graph_Module
{
    [Serializable]
    public class EE : IExpressionExternal
    {
        CalcExpr.ValueType IExpressionExternal.ret_type => m_type;
        CalcExpr.ValueType m_type;

        public List<(string name, bool is_p)> sub_infos_tree = new();
        public string complete_content;

        //================================================================================================

        public EE(string attr_name, Type type, bool need_complete)
        {
            complete_content = attr_name;
            var names = attr_name.Split('.');

            bool is_first_load_end = false;
            var ps = type.GetProperties();
            foreach (var p in ps)
            {
                var attr = p.GetCustomAttribute<Attributes.ExprConstAttribute>();
                if (attr == null) continue;

                if ((need_complete && attr.name.Contains(names[0])) || (!need_complete && attr.name == names[0]))
                {
                    names[0] = p.Name;
                    is_first_load_end = true;
                    break;
                }
            }

            if (!is_first_load_end)
            {
                var fs = type.GetFields();
                foreach (var f in fs)
                {
                    var attr = f.GetCustomAttribute<Attributes.ExprConstAttribute>();
                    if (attr == null) continue;

                    if ((need_complete && attr.name.Contains(names[0])) || (!need_complete && attr.name == names[0]))
                    {
                        names[0] = f.Name;
                        is_first_load_end = true;
                        break;
                    }
                }
            }

            foreach (var (_name, index) in names.Select((value, i) => (value, i)))
            {
                var name = _name;

                IEnumerable<PropertyInfo> pi;
                if (need_complete)
                    pi = type.GetProperties().Where(t => t.Name.Contains(_name));
                else
                    pi = type.GetProperties().Where(t => t.Name == _name);

                if (pi != null && pi.Any())
                {
                    type = pi.First().PropertyType;
                    name = pi.First().Name;

                    sub_infos_tree.Add((name, true));
                    continue;
                }

                IEnumerable<FieldInfo> fi;
                if (need_complete)
                    fi = type.GetFields().Where(t => t.Name.Contains(_name));
                else
                    fi = type.GetFields().Where(t => t.Name == _name);

                if (fi != null && fi.Any())
                {
                    type = fi.First().FieldType;
                    name = fi.First().Name;

                    sub_infos_tree.Add((name, false));
                    continue;
                }

                return;
            }

            //装载类型
            get_value_type(type, out m_type);

            //装载content
            if (need_complete)
            {
                string content = "";
                foreach (var (name, _) in sub_infos_tree)
                {
                    content = $"{content}.{name}";
                }

                complete_content = content.TrimStart('.');
            }
        }


        bool IExpressionExternal.get_value(object obj, Type _, out object value)
        {
            value = default;

            foreach (var (name, is_p) in sub_infos_tree)
            {
                if (is_p)
                    obj = obj.GetType().GetProperty(name).GetValue(obj);
                else
                    obj = obj.GetType().GetField(name).GetValue(obj);
            }

            value = obj;
            return true;
        }


        bool IExpressionExternal.set_external(Calculator calculator, object obj, Type obj_type, int index)
        {
            throw new NotImplementedException();
        }


        public static bool set_external(Calculator calculator, IExpressionExternal iee, int index, object value)
        {
            switch (iee.ret_type)
            {
                case CalcExpr.ValueType.Integer:
                    calculator.set_external(index, (int)value);
                    break;
                case CalcExpr.ValueType.Floating:
                    calculator.set_external(index, (float)value);
                    break;
                case CalcExpr.ValueType.Boolean:
                    calculator.set_external(index, (bool)value);
                    break;
            }
            return true;
        }


        //================================================================================================

        public static bool get_value_type(Type type, out CalcExpr.ValueType ty)
        {
            if (type == typeof(int))
            {
                ty = CalcExpr.ValueType.Integer;
                return true;
            }
            if (type == typeof(float) || type == typeof(System.Single))
            {
                ty = CalcExpr.ValueType.Floating;
                return true;
            }
            if (type == typeof(bool))
            {
                ty = CalcExpr.ValueType.Boolean;
                return true;
            }
            ty = CalcExpr.ValueType.Unknown;
            return false;
        }
    }
}

