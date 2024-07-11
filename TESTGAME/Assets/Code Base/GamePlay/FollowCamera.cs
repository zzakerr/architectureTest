using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform m_Target;

    [SerializeField] private float m_InterpolationLinear;

    [SerializeField] private float m_CameraZOffset;
    [SerializeField] private float m_ForwardOffset;

    private void FixedUpdate()
    {
        if (m_Target == null) return;

        Vector2 camPos = Camera.main.transform.position;
        Vector2 targetPos = m_Target.position + m_Target.transform.up * m_ForwardOffset;
         
        Vector2 newCamPos = Vector2.Lerp(camPos,targetPos, m_InterpolationLinear * Time.deltaTime);

        transform.position = new Vector3(newCamPos.x, newCamPos.y, m_CameraZOffset);
    }

    public void SetTarget(Transform newTarget)
    {
        m_Target = newTarget;
    }
}
