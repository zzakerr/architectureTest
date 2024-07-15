using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
   public enum ControlMode
    {
        Keyboard,
        Mobile
    }

    [SerializeField] private ControlMode m_ControlMode;

    private VirtualGamePad virtualGamePad;
    private Canvas inventoryPanel;
    private Character targetCharacter;

    public void SetTargetCharacter(Character character) => targetCharacter = character;

    public void Construct(VirtualGamePad virtualGamePad,GameObject inventoryPanel)
    {
        this.virtualGamePad = virtualGamePad;
        this.inventoryPanel = inventoryPanel.GetComponent<Canvas>();
    }

    private void Start()
    {
        if(m_ControlMode == ControlMode.Keyboard)
        {
            virtualGamePad.joystick.gameObject.SetActive(false);
            virtualGamePad.mobileFire.gameObject.SetActive(false);
            virtualGamePad.mobileinventory.gameObject.SetActive(false);
            inventoryPanel.enabled = false;
        }
        else
        {
            virtualGamePad.joystick.gameObject.SetActive(true);
            virtualGamePad.mobileFire.gameObject.SetActive(true);
            virtualGamePad.mobileinventory.gameObject.SetActive(true);
            inventoryPanel.gameObject.SetActive(false);
        }
 
    }

    private void Update()
    {
        if(targetCharacter == null) return;
        if(m_ControlMode == ControlMode.Keyboard) ControlKeyboard(); 
        if(m_ControlMode == ControlMode.Mobile) ControlMobile(); 
    }

    private void ControlMobile()
    {
        var dir = virtualGamePad.joystick.Value;
        targetCharacter.linearY = dir.y;
        targetCharacter.linearX = dir.x;

        if (virtualGamePad.mobileinventory.IsClick == true)
        {
            inventoryPanel.gameObject.SetActive(true);
        }
        else
        {
            inventoryPanel.gameObject.SetActive(false);
        }

        if (virtualGamePad.mobileFire.IsHold == true)
        {
            targetCharacter.Fire();
        }

    }

    private bool IsActive;
    private void ControlKeyboard()
    {
        int moveY = 0;
        int moveX = 0;

        if (Input.GetKey(KeyCode.W)) moveY = 1;
        if (Input.GetKey(KeyCode.S)) moveY = -1;
        if (Input.GetKey(KeyCode.D)) moveX = 1;
        if (Input.GetKey(KeyCode.A)) moveX = -1;

        targetCharacter.linearY = moveY;
        targetCharacter.linearX = moveX;

        if (Input.GetKey(KeyCode.Space))
        {
            targetCharacter.Fire();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsActive = !IsActive;
            inventoryPanel.enabled = IsActive;     
        }

    }

}
