using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "CustomerData", menuName = "GameData/CustomerData", order = 0)]
    public class CustomerData : ScriptableObject
    {
    
        [SerializeField] GameObject _coffeSprite;
    
        private int _price;

        public float MoveSpeed = 1.4f;
        
        public GameObject GetGameObject =>_coffeSprite;
    }

}
