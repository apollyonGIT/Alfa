
using System.Collections.Generic;

namespace Foundation {

    public interface IModel<T, V> where V : class, IModelView<T> {
        bool add_view(V view);
        bool remove_view(V view);
        void clear_views();
        ReadOnlyList<V> views { get; }
    }

    public interface IModelView<T> {
        void attach(T owner);
        void detach(T owner);
    }

    public class Model<T, V> : IModel<T, V>
        where T : class, IModel<T, V>
        where V : class, IModelView<T> {

        public ReadOnlyList<V> views => m_views;

        public bool add_view(V view) {
            if (m_views.Contains(view)) {
                return false;
            }
            m_views.Add(view);
            view.attach(this as T);
            return true;
        }

        public bool remove_view(V view) {
            var idx = m_views.IndexOf(view);
            if (idx >= 0) {
                var last = m_views.Count - 1;
                if (last != idx) {
                    m_views[idx] = m_views[last];
                }
                m_views.RemoveAt(last);
                view.detach(this as T);
                return true;
            }
            return false;
        }


        public void clear_views() {
            foreach (var view in m_views) {
                view.detach(this as T);
            }
            m_views.Clear();
        }


        private List<V> m_views = new List<V>();
    }
        

}