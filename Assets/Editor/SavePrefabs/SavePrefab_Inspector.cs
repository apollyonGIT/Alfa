using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SavePrefab))]
    public class SavePrefab_Inspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("do"))
            {
                var instance = (SavePrefab)target;
                instance.@do();
            }
        }
    }
}

