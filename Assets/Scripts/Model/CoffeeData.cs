using UnityEngine;
using Enums;

namespace Model
{
    [CreateAssetMenu(fileName = "CoffeeData", menuName = "GameData/CoffeeData", order = 0)]
    public class CoffeeData : ScriptableObject
    {

        [SerializeField] private Sprite _sprite;
        [SerializeField] private  CoffeeType _coffeeType;
        [SerializeField] private int[] _sellValue;
        [SerializeField] private int[] _upgradeCost;
        [SerializeField] private float[] _manifactureTime;

        private int _upGradeAmount;
        public Sprite Sprite => _sprite;
        public CoffeeType GetCoffeeType => _coffeeType;

        public int GetUpgradeCost()
        {
            if(_upGradeAmount + 1 < _upgradeCost.Length)
            {
                return _upgradeCost[_upGradeAmount + 1];
            }
            return 0;
        }

        public void IncreaseUpGradeCost() => _upGradeAmount += 1;
        public int GetSellPrice() => _sellValue[_upGradeAmount];
        public float GetManufactureTime() => _manifactureTime[_upGradeAmount];
        public bool CanUpgrade() => _upGradeAmount <= _upgradeCost.Length;

        public void ResetUpgrade() => _upGradeAmount = 0;
    }
}
