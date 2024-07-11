using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private FollowCamera followCamera;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private CharacterInputController characterInputController;
    [SerializeField] private VirtualGamePad virtualGamePadPrefab;

    [SerializeField] private Transform spawnPoint;

    public Player Spawn()
    {
        FollowCamera camera = Instantiate(followCamera);
        VirtualGamePad gamepad = Instantiate(virtualGamePadPrefab);

        CharacterInputController inputController = Instantiate(characterInputController);
        inputController.Construct(gamepad);

        Player player = Instantiate(playerPrefab);
        player.Construct(camera, inputController, spawnPoint);

        return player;
    }

}
