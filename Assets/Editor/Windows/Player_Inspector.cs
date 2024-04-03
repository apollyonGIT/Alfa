#if  UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using World;

namespace Editor.Windows
{
    public class Player_Inspector : EditorWindow
    {


        //================================================================================================

        [MenuItem("EditorWindow/Player_Inspector _F4")]
        public static void ShowWindow()
        {
            GetWindow(typeof(Player_Inspector));
        }


        private void OnGUI()
        {
            if (!WorldContext.instance.is_battle)
            {
                GUILayout.Label("请先进入战斗");
                return;
            }
        }
    }
}

#endif