using UnityEngine;
using GenericPoolSystem.PoolData;


[CreateAssetMenu(fileName = "CustomerPool", menuName = "Pool/CustomerPool", order = 0)]
public class CustomerPool : AbstractPool<string>
{
    private CustomerPool()
    {
        Key = "CustomerPool";
        InitialSize = 15;
        IsExtensible = false;
    }
}