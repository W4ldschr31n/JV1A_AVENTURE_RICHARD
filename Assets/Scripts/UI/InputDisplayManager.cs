using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputDisplayManager : MonoBehaviour
{
    // External component
    private InputManager inputManager;
    // Properties
    public bool isKeyboard;
    public bool canDisplayJudgement, canDisplayObole, canDisplayCharge;
    // Event
    public static Action onInputPressed;

    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

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
