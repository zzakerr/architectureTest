using UnityEngine;
using Common;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : Destructible
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Transform view;

    private float speed;
    private Rigidbody2D rigid;

    [HideInInspector] public float linearX;
    [HideInInspector] public float linearY;


    private void Start()
    {
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

    }
}
