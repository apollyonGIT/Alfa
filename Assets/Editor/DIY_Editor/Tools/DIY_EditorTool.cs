using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Editor.DIY_Editor.Tools
{
    public class DIY_EditorTool: EditorTool
    {
        protected GUIContent m_icon;
        public override GUIContent toolbarIcon => m_icon;

        public Component root;

        //==================================================================================================

        public virtual void init(Component root, string icon_image_path, string icon_text)
        {
            m_icon = new()
            {
                image = EditorGUIUtility.IconContent(icon_image_path).image,
                text = icon_text,
                tooltip = icon_text,
            };

            this.root = root;
        }
    }
}

