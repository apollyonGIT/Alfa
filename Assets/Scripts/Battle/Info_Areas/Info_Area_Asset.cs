using UnityEngine;

namespace Battle.Info_Areas
{
    [CreateAssetMenu(fileName = "Info_Area_Asset", menuName = "DIY_Asset/Info_Area_Asset")]
    public class Info_Area_Asset : ScriptableObject
    {
        public Info[] attack_area;

        //==================================================================================================

        [System.Serializable]
        public struct Info
        {
            public int x;
            public int y;
        }
    }
}

