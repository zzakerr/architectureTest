using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject PlayerHUDPrefab;
    

    [Header("Dependencies")]
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private LevelBoundary levelBoundary;

    private void Awake()
    {
        levelBoundary.Init();

        Player player = playerSpawner.Spawn();

        player.Init();

        Instantiate(PlayerHUDPrefab);     
    }


}
