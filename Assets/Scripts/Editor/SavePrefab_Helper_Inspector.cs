using Common;
using UnityEditor;
using UnityEngine;

namespace Editors.Inspectors
{
    [CustomEditor(typeof(SavePrefab_Helper))]
    public class SavePrefab_Helper_Inspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("do"))
            {
                var instance = (SavePrefab_Helper)target;
                instance.@do();
            }
        }
    }
}

