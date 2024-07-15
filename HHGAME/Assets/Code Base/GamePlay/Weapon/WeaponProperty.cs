using UnityEngine;
using Common;

[CreateAssetMenu(fileName = "WeaponProperty", menuName = "ScriptableObjects/WeaponProperty")]
public sealed class WeaponProperty : ScriptableObject
{

    [SerializeField] private ProjectileBase projectilePrefab;
    public ProjectileBase ProjectilePrefab => projectilePrefab;

    [SerializeField] private float rateOfFire;
    public float RateOfFire => rateOfFire;

    [SerializeField] private ItemObject itemBullet;
    public ItemObject ItemBullet => itemBullet;
}
