using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponProperty weaponProperty;

    private float refire_Timer;

    public bool CanFire => refire_Timer <= 0;

    private Character character;

    private void Start()
    {
        character = transform.root.GetComponent<Character>();
    }

    private void Update()
    {
        if (refire_Timer > 0) 
        {
            
        }
        refire_Timer -= Time.deltaTime;
    }

    public void Fire()
    {
        if (weaponProperty == null) return;

        if (refire_Timer > 0) return;

        Projectile projectile = Instantiate(weaponProperty.ProjectilePrefab).GetComponent<Projectile>();
        projectile.SetParrentShoter(character);
        projectile.transform.position = transform.position;
        projectile.transform.up = transform.up;

        refire_Timer = weaponProperty.RateOfFire;
        
    }

    public void AssignLoadout(WeaponProperty props)
    {
        refire_Timer = 0;
        weaponProperty = props;
    }
}
