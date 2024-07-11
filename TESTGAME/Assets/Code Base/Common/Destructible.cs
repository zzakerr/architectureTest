using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructible : Entity
{
    [SerializeField] private bool isDestructible;
    [SerializeField] private int maxHitPoints;
    [SerializeField] private int teamID;

    private int currentHitPoint;

    public bool IsDestructible => isDestructible;
    public int CurrentHitPoint => currentHitPoint;
    public int MaxHitPoint => maxHitPoints;
    public int TeamID => teamID;

    public UnityEvent EventOnDeath;
    public UnityEvent EventOnHit;

    protected virtual void Start()
    {
        currentHitPoint = maxHitPoints;
    }

    public void ApplyDamage(int damage)
    {
        if (IsDestructible) return;

        if (currentHitPoint - damage <= 0)
        {
            OnDeath();
        }

        else
        {
            EventOnHit.Invoke();
            currentHitPoint -= damage;
        }
    }

    public void AddHitPoint(int health)
    {
        if (currentHitPoint + health <= maxHitPoints)
        {
            currentHitPoint = maxHitPoints;
        }
        else
        {
            currentHitPoint += health;
        }
    }

    protected virtual void OnDeath()
    {
        EventOnDeath.Invoke();
        Destroy(gameObject);
        Debug.Log("Я умер");
    }

    private static HashSet<Destructible> m_AllDestructibles;

    public static IReadOnlyCollection<Destructible> AllDestructibles => m_AllDestructibles;

    protected virtual void OnEnable()
    {
        if (m_AllDestructibles == null)
            m_AllDestructibles = new HashSet<Destructible>();

        m_AllDestructibles.Add(this);
    }

    protected virtual void OnDestroy()
    {
        m_AllDestructibles.Remove(this);
    }
}
