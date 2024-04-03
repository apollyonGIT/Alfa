using UnityEditor;

namespace Editor.DIY_Editor.Arrival_Editor
{
    [CustomEditor(typeof(Scope_Root), true)]
    public class Scope_RootEditor : RootEditor
    {
        Scope_Root root;
        Scope_Tool_Brush m_brush;

        //==================================================================================================

        private void OnEnable()
        {
            root = (Scope_Root)target;

            m_brush = CreateInstance<Scope_Tool_Brush>();
            m_brush.init(root, "d_TerrainInspector.TerrainToolSplat", "info_area");
        }


        private void OnDisable()
        {
            DestroyImmediate(m_brush);
        }


        protected override void OnInspectorGUI_Up()
        {
            EditorGUILayout.Space();
            EditorGUILayout.EditorToolbar(m_brush);
        }
    }
}

