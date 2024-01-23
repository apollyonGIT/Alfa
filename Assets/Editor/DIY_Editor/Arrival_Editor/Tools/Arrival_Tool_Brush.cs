using UnityEngine;

namespace Editor.DIY_Editor.Arrival_Editor
{
    public class Arrival_Tool_Brush : Tool
    {
        protected override void left_click(object[] args)
        {
            root.GetType().GetMethod("do_brush")?.Invoke(root, args);
        }


        protected override void right_click(object[] args)
        {
            root.GetType().GetMethod("do_erase")?.Invoke(root, args);
        }
    }
}

