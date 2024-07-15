using UnityEngine;
using Common;


[RequireComponent(typeof(Character))]
public class AIController : MonoBehaviour
{

    [Header("Скорость стрельбы")]
    [SerializeField] private float shotDelay;

    [Header("Таймер поиска новой Цели")]
    [SerializeField] private float findNewTargetTime;

    private Character character;

    private Vector3 movePos;

    private Vector3 StartPos;

    private Destructible selectedTarget;

    private Timer FireTimer;

    private Timer FindNewTargetTimer;


    private void Start()
    {
        StartPos = transform.position;
        movePos = StartPos;
        character = GetComponent<Character>();
        InitTimers();        
    }


    private void FixedUpdate()
    {
        UpdateTimers();
        UpdateAI();
    }

    private void UpdateAI()
    {
        ActionFindMovePosition();
        ActionControlCharacter();
        ActionFindNewAttacTarget();
    }

    private void ActionFindMovePosition()
    {
        if (selectedTarget != null)
        {
            movePos = (Vector2)selectedTarget.transform.position;
        }
        else
        {
            movePos = StartPos;
        }
    }

    private void ActionControlCharacter()
    {
        Vector2 dir = (movePos - character.transform.position).normalized;
        character.linearX = dir.x;
        character.linearY = dir.y;
    }

    private void ActionFindNewAttacTarget()
    {
        if (FindNewTargetTimer.IsFinished == true)
        {
            selectedTarget = FindNearestDestructibleTarget();

            FindNewTargetTimer.Start(findNewTargetTime);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.root.GetComponent<Character>() != null)
        {
            if(collision.transform.root.GetComponent<Character>().TeamID != character.TeamID)
            {
                ActionFire(collision.transform.root.GetComponent<Character>());
            }        
        }
    }

    private void ActionFire(Character character)
    {
        if(selectedTarget != null && FireTimer.IsFinished)
        {
            character.ApplyDamage(this.character.Damage);
            FireTimer.Start(shotDelay);
        }
    }

    private Destructible FindNearestDestructibleTarget()
    {
        float maxDist = character.RadiusAim;

        Destructible potentialTarget = null;

        foreach (var v in Destructible.AllDestructibles)
        {
            if (v.GetComponent<Character>() == character) continue;

            if (v.TeamID == character.TeamID) continue;

            float dist = Vector2.Distance(character.transform.position, v.transform.position);

            if (dist < maxDist)
            {
                maxDist = dist;
                potentialTarget = v;
            }
        }

        return potentialTarget;
    }


    private void InitTimers()
    {
        FindNewTargetTimer = new Timer(findNewTargetTime);
        FireTimer = new Timer(shotDelay);
    }

    private void UpdateTimers()
    {
        FindNewTargetTimer.RemoveTime(Time.deltaTime);
        FireTimer.RemoveTime(Time.deltaTime);
    }

}
