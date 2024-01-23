using UnityEditor;

namespace Editor.DIY_Editor.Arrival_Editor
{
    [CustomEditor(typeof(Arrival_Root), true)]
    public class Arrival_RootEditor : RootEditor
    {
        Arrival_Root root;
        Arrival_Tool_Brush m_brush;

        //==================================================================================================

        private void OnEnable()
        {
            root = (Arrival_Root)target;

            m_brush = CreateInstance<Arrival_Tool_Brush>();
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

