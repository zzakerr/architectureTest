using UnityEngine;
using Common;

[CreateAssetMenu]
public sealed class WeaponProperty : ScriptableObject
{

    [SerializeField] private ProjectileBase projectilePrefab;
    public ProjectileBase ProjectilePrefab => projectilePrefab;

    [SerializeField] private float rateOfFire;
    public float RateOfFire => rateOfFire;
}
