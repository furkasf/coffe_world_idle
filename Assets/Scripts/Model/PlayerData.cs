using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "GameData/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        private float _prepSpeed = 1.5f;
        public float MoveSpeed;
        
        public float PrepSpeed => _prepSpeed;

        public void UpgradeSpeed () => _prepSpeed -= 0.2f;

        public void Reset()
        {
            _prepSpeed = 1.5f;
        }
    }
}
