using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class SavePrefab_Helper : MonoBehaviour
    {
        public GameObject target_prefab;
        public GameObject source_prefab;

        public void @do()
        {
            PrefabUtility.SaveAsPrefabAsset(target_prefab, AssetDatabase.GetAssetPath(source_prefab));
        }
    }
}

