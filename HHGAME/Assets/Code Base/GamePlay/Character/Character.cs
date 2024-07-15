using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : Destructible
{
    [Header("Урон")]
    [Range(1f, 100f)]
    [SerializeField] private int damage;

    [Header("Дальность Видимости цели")]
    [SerializeField] private float radiusAim;

    [Header("Скорость")]
    [SerializeField] private float startSpeed;

    [Header("Максимальная скорость")]
    [SerializeField] private float maxSpeed;

    [Header("View сущности")]
    [SerializeField] private Transform view;

    [Header("Слот с оружием")]
    [SerializeField] private Weapon weapon;

    [HideInInspector] public float linearX;
    [HideInInspector] public float linearY;

    private float speed;
    private Rigidbody2D rigid;

    public float Speed => speed;
    public int Damage => damage;
    public float RadiusAim => radiusAim;

    protected override void Start()
    {
        base.Start();
        speed = startSpeed;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        UpdateRigidbody();
        ViewRotate();
    }


    private void UpdateRigidbody()
    {
        rigid.AddForce(linearX * speed * transform.right * Time.fixedDeltaTime, ForceMode2D.Force);    
        rigid.AddForce(linearY * speed * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);
        rigid.AddForce(-rigid.velocity * (speed / maxSpeed) * Time.fixedDeltaTime, ForceMode2D.Force); 
    }

    private void ViewRotate()
    {
        if (linearX < 0) view.rotation = new Quaternion(0,180,0,0);
        if (linearX > 0) view.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void Fire()
    {
        if (GetNearestTargetPosition() != Vector2.zero)
        {
            weapon.Fire(GetNearestTargetPosition());
        }     
    }

    public Vector2 GetNearestTargetPosition()
    {
        float maxDist = radiusAim;

        Destructible potentialTarget = null;

        foreach (var v in AllDestructibles)
        {
            if (v.GetComponent<Character>() == this) continue;

            if (v.TeamID == TeamID) continue;

            float dist = Vector2.Distance(transform.position, v.transform.position);

            if (dist < maxDist)
            {
                maxDist = dist;
                potentialTarget = v;
            }
        }

        if (potentialTarget != null)
        {
            return potentialTarget.GetComponent<Transform>().position;
        }
        else
        {
            return Vector2.zero;
        }     
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radiusAim);
    }
}
