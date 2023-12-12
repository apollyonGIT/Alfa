using Editor.DIY_Editor.Tools;
using UnityEditor;

namespace Editor.DIY_Editor.Info_Area_Editor
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

