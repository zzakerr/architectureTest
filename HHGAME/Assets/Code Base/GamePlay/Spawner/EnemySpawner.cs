using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnMode
    {
        Start,
        Loop
    }

    [SerializeField] private Entity[] entitiesPrefabs;

    [SerializeField] SpawnMode spawnMode;

    [SerializeField] private int numSpawns;

    [SerializeField] private float respawnTime;

    [SerializeField] private int teamID;

    [SerializeField] private float SpawnRadius;

    private float timer;

    private void Start()
    {
        if (spawnMode == SpawnMode.Start)
        {
            SpawnEntities();
        }
        timer = respawnTime;
    }


    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;

        if (spawnMode == SpawnMode.Loop && timer < 0)
        {
            SpawnEntities();

            timer = respawnTime;
        }
    }

    private void SpawnEntities()
    {
        for (int i = 0; i < numSpawns; i++)
        {
            int index = Random.Range(0, entitiesPrefabs.Length);

            GameObject e = Instantiate(entitiesPrefabs[index].gameObject);

            e.GetComponent<Destructible>().SetTeamID(teamID);

            e.transform.position = GetRandomInsideZone();
        }
    }

    public Vector2 GetRandomInsideZone()
    {
        return (Vector2)transform.position + (Vector2)Random.insideUnitSphere * SpawnRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SpawnRadius);
    }
}

