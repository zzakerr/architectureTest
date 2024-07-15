using UnityEngine;

[RequireComponent(typeof(Character))]
public class HitPointBarEnemy: MonoBehaviour
{
    [SerializeField] private SpriteRenderer image;
    private Character character;
    private float lastHitPoints;

    private void Start()
    {
       character = GetComponent<Character>();
    }

    private void Update()
    {
        float hitpoints = (float)character.CurrentHitPoint / (float)character.MaxHitPoint;

        if (hitpoints != lastHitPoints)
        {
            image.size = new Vector2(hitpoints, 1);
            lastHitPoints = hitpoints;
        }  
    }
}
