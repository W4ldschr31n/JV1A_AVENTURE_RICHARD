using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput;
    public bool ToggleInventoryInput;
    public bool InteractInput;
    public bool AttackJudgementInput;
    public bool AttackOboleInput;
    public bool AttackChargeInput;

    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction toggleInventoryAction;
    private InputAction interactAction;
    private InputAction attackJudgementAction;
    private InputAction attackOboleAction;
    private InputAction attackChargeAction;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        toggleInventoryAction = playerInput.actions["ToggleInventory"];
        interactAction = playerInput.actions["Interact"];
        attackJudgementAction = playerInput.actions["AttackJudgement"];
        attackOboleAction = playerInput.actions["AttackObole"];
        attackChargeAction = playerInput.actions["AttackCharge"];
    }

    private void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        ToggleInventoryInput = toggleInventoryAction.WasPressedThisFrame();
        InteractInput = interactAction.WasPressedThisFrame();
        AttackJudgementInput = attackJudgementAction.WasPressedThisFrame();
        AttackOboleInput = attackOboleAction.WasPressedThisFrame();
        AttackChargeInput = attackChargeAction.WasPressedThisFrame();
    }
}
