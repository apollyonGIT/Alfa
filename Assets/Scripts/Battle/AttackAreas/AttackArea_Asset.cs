using UnityEngine;

namespace Battle.AttackAreas
{
    [CreateAssetMenu(fileName = "attack_area_asset", menuName = "DIY_Asset/Attack_Area")]
    public class AttackArea_Asset : ScriptableObject
    {
        public pos[] pos_array;

        [System.Serializable]
        public struct pos
        {
            public int x;
            public int y;
        }
    }
}




