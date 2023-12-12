using Battle;
using UnityEditor;
using UnityEngine;

namespace DIY_Editor.Info_Area_Editor
{
    public class Info_Area_Brush : Brush
    {
        int m_id;

        //==================================================================================================

        protected override void draw_win_content()
        {
            m_id = Mathf.Max(0, EditorGUILayout.IntField("Id", m_id));
            EditorGUILayout.LabelField(" ", "<Invalid>");
        }
    }
}

