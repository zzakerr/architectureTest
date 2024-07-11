using UnityEngine;
using UnityEngine.Events;

public class Destructible : Entity
{
    [SerializeField] private bool isDestructible;
    [SerializeField] private int maxHitPoints;

    private int currentHitPoint;

    public bool IsDestructible => isDestructible;
    public int CurrentHitPoint => currentHitPoint;

    public UnityEvent EventOnDeath;

    private void Start()
    {
        currentHitPoint = maxHitPoints;
    }

    public void ApplyDamage(int damage)
    {
        if (!IsDestructible) return;

        if (currentHitPoint - damage <= 0)
        {
            EventOnDeath.Invoke();
        }
        else
        {
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
        Debug.Log("Я умер");
    }
}
