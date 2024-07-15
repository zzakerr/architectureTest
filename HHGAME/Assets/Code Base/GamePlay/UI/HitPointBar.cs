using UnityEngine;
using UnityEngine.UI;

public class HitPointBar : MonoBehaviour
{
    [SerializeField] private Image image;

    private float lastHitPoints;

    private void Update()
    {
        float hitpoints = (float)Player.Instance.ActivCharacter.CurrentHitPoint / (float)Player.Instance.ActivCharacter.MaxHitPoint;
        if (hitpoints != lastHitPoints)
        {
            image.fillAmount = hitpoints;
            lastHitPoints = hitpoints;
        }  
    }
}
