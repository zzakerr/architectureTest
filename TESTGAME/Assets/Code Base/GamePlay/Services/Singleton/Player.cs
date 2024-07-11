using UnityEngine;
using Common;

public class Player : SingletonBase<Player>
{
    public static Character SelectedCharacter;

    [SerializeField] private int numLives;
    
    [SerializeField] private Character PlayerCharacterPref;

    private FollowCamera followCamera;
    private Character character;
    private CharacterInputController characteInputController;
    private Transform spawnPoint;

    private int score;
    private int numKill;

    public int Score => score;
    public int NumKill => numKill;
    public int NumLives => numLives;
    public Character ActivCharacter => character;

    public void Construct(FollowCamera camera,CharacterInputController characteInputController,Transform spawnPoint)
    {
        followCamera = camera;
        this.characteInputController = characteInputController;
        this.spawnPoint = spawnPoint;
    }


    public Character ChatacterPrefab 
    { 
        get
        {
            if(SelectedCharacter == null)
            {
                return PlayerCharacterPref;
            }
            else
            {
                return SelectedCharacter;
            }
        }
       
    }

    private void Start()
    {   
        Respawn();  
    }

    private void OnShipDeath()
    {
        character.EventOnDeath.RemoveAllListeners();
        numLives--;
        if (numLives > 0) Respawn();
    }
   
    private void Respawn()
    {
        var newPlayerShip = Instantiate(ChatacterPrefab , spawnPoint.position, spawnPoint.rotation);

        character = newPlayerShip.GetComponent<Character>();
        followCamera.SetTarget(character.transform);
        characteInputController.SetTargetCharacter(character);
        character.EventOnDeath.AddListener(OnShipDeath);
    }

    public void AddKill()
    {
        numKill++;
    }

    public void AddScore(int score)
    {
        this.score += score;
    }
   
}
