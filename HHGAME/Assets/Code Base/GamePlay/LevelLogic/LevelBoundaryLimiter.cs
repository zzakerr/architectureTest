using UnityEngine;

public class LevelBoundaryLimiter : MonoBehaviour
{
    private void Update()
    {
        if (LevelBoundary.Instance == null) return;

        var lb = LevelBoundary.Instance;
        var r = lb.Radius;

        if (transform.position.magnitude > r)
        {
            if(lb.LimitMode == LevelBoundary.Mode.Limit)
            {
                transform.position = transform.position.normalized * r;
            }

            if (lb.LimitMode == LevelBoundary.Mode.Teleport)
            {
                transform.position = -transform.position.normalized * r;
            }
        }
    }
}
