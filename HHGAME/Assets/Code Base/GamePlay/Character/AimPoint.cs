using UnityEngine;

[RequireComponent(typeof(Character))]
public class AimPoint : MonoBehaviour
{
    [SerializeField] private GameObject markPrefab;
    private SpriteRenderer view;
    private Character character;

    private void Start()
    {
        view = Instantiate(markPrefab).GetComponent<SpriteRenderer>();
        character = GetComponent<Character>();
    }

    private void FixedUpdate()
    {
        if (character.GetNearestTargetPosition() != Vector2.zero)
        {
            view.enabled = true;
            view.transform.position = character.GetNearestTargetPosition();
        }
        else
        {
            view.enabled = false;
        }    
    }
}
