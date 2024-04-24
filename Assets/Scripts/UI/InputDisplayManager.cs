using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputDisplayManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isKeyboard;
    private InputManager inputManager;
    public static Action onInputPressed;

    public bool canDisplayJudgement, canDisplayObole, canDisplayCharge;
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Unity does not detect D-Pad and Joystick so force their detection
        if (Input.anyKey || inputManager.MoveInput != Vector2.zero)
        {
            isKeyboard = Keyboard.current.anyKey.isPressed || Keyboard.current.anyKey.wasReleasedThisFrame;
            onInputPressed?.Invoke();
        }
    }
}
