using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
   public enum ControlMode
    {
        Keyboard,
        Mobile
    }

    [SerializeField] private ControlMode m_ControlMode;

    private VirtualGamePad virtualGamepad;
    private Character targetCharacter;

    public void SetTargetCharacter(Character character) => targetCharacter = character;

    public void Construct(VirtualGamePad virtualGamePad)
    {
        virtualGamepad = virtualGamePad;
    }

    private void Start()
    {
        if(m_ControlMode == ControlMode.Keyboard)
        {
            virtualGamepad.joystick.gameObject.SetActive(false);
            virtualGamepad.mobileFirePrimary.gameObject.SetActive(false);
            virtualGamepad.mobileFireSecondary.gameObject.SetActive(false);

        }
            
        else
        {
            virtualGamepad.joystick.gameObject.SetActive(true);
            virtualGamepad.mobileFirePrimary.gameObject.SetActive(true);
            virtualGamepad.mobileFireSecondary.gameObject.SetActive(true);
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
        var dir = virtualGamepad.joystick.Value;
        targetCharacter.linearY = dir.y;
        targetCharacter.linearX = dir.x;
    }

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
            
        }

    }

}
