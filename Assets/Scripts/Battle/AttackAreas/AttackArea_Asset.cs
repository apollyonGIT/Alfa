using UnityEngine;

namespace Battle.AttackAreas
{
    [CreateAssetMenu(fileName = "attack_area_asset", menuName = "DIY_Asset/attack_area")]
    public class AttackArea_Asset : ScriptableObject
    {
        public (int, int) pos_array;
    }
}




