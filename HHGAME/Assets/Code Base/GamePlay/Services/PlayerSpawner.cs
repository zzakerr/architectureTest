using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private FollowCamera followCamera;
    [SerializeField] private GameObject PlayerGUI;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private CharacterInputController characterInputController;
    [SerializeField] private VirtualGamePad virtualGamePadPrefab;
    [SerializeField] private Transform spawnPoint;

    public Player Spawn()
    {
        FollowCamera camera = Instantiate(followCamera);
        VirtualGamePad gamepad = Instantiate(virtualGamePadPrefab);
        GameObject inventoryPanel = Instantiate(PlayerGUI);
        CharacterInputController inputController = Instantiate(characterInputController);

        inputController.Construct(gamepad, inventoryPanel);
        Player player = Instantiate(playerPrefab);
        player.Construct(camera, inputController, spawnPoint);

        return player;
    }

}
