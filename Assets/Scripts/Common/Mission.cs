using System.Collections.Generic;

namespace Common
{
    public interface IMgr
    {
        public string name { get; }
        void init(params object[] objs);
        void fini();
        bool try_get_cell(out object cell, params object[] prms);
    }


    public class Mission : Singleton<Mission>
    {
        Dictionary<string, IMgr> m_mgrs_dic = new();

        //==================================================================================================

        public void attach_mgr(string name, IMgr mgr)
        {
            EX_Utility.dic_cover_add(ref m_mgrs_dic, name, mgr);
        }


        public void detach_mgr(string name)
        {
            EX_Utility.dic_safe_remove(ref m_mgrs_dic, name);
        }


        public bool try_get_mgr(string name, out IMgr mgr)
        {
            return m_mgrs_dic.TryGetValue(name, out mgr);
        }


        public bool try_get_mgr<T>(string name, out T mgr) where T : class, IMgr
        {
            mgr = null;
            if (!try_get_mgr(name, out var imgr)) return false;

            mgr = imgr as T;
            return true;
        }


        public void remove_all_mgr()
        {
            m_mgrs_dic.Clear();
        }


        public object do_mgr_method(IMgr mgr, string method_name, object[] prms)
        {
            var mi = mgr.GetType().GetMethod(method_name);
            if (mi == null) return null;

            return mi.Invoke(mgr, prms);
        }


        public bool try_get_cell_field<T>(object cell, string fn, out T field)
        {
            field = default;

            var fi = cell.GetType().GetField(fn);
            if (fi == null) return false;

            var v = fi.GetValue(cell);
            if (v is not T) return false;

            field = (T)v;
            return true;
        }


        public bool try_get_cell_prop<T>(object cell, string pn, out T prop)
        {
            prop = default;

            var pi = cell.GetType().GetProperty(pn);
            if (pi == null) return false;

            var v = pi.GetValue(cell);
            if (v is not T) return false;

            prop = (T)v;
            return true;
        }

    }
}

