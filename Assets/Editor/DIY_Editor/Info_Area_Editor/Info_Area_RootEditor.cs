using Editor.DIY_Editor;
using UnityEditor;

namespace DIY_Editor.Info_Area_Editor
{
    [CustomEditor(typeof(Info_Area_Root), true)]
    public class Info_Area_RootEditor : RootEditor
    {
        Info_Area_Root root;
        Info_Area_Brush m_brush;

        //==================================================================================================

        private void OnEnable()
        {
            root = (Info_Area_Root)target;

            m_brush = CreateInstance<Info_Area_Brush>();
            m_brush.init("d_TerrainInspector.TerrainToolSplat On", "info_area");
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

