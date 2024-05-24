using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private HeroMove inputActions;
    private Hero hero;

    private void Awake()
    {
        inputActions = new HeroMove();
        hero = FindObjectOfType<Hero>(); // Assurez-vous qu'il n'y a qu'un seul Hero dans la scène
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += hero.OnMove;
        inputActions.Player.Move.canceled += hero.OnMove;
        inputActions.Player.Jump.performed += hero.OnJump;
        inputActions.Player.Create.performed += hero.OnInvoqueTurret;
        inputActions.Player.nextPrefab.performed += hero.OnNextPrefab;
        inputActions.Player.prevPrefab.performed += hero.OnPrevPrefab;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= hero.OnMove;
        inputActions.Player.Move.canceled -= hero.OnMove;
        inputActions.Player.Jump.performed -= hero.OnJump;
        inputActions.Player.Create.performed -= hero.OnInvoqueTurret;
        inputActions.Player.nextPrefab.performed -= hero.OnNextPrefab;
        inputActions.Player.prevPrefab.performed -= hero.OnPrevPrefab;
        inputActions.Disable();
    }


    public void RebindMove()
    {
        inputActions.Player.Move.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnComplete(operation => Debug.Log("Rebinding Complete!"))
            .Start();
    }

    public void RebindJump()
    {
        inputActions.Player.Jump.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnComplete(operation => Debug.Log("Rebinding Complete!"))
            .Start();
    }

    public void RebindCreat()
    {
        inputActions.Player.Create.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnComplete(operation => Debug.Log("Rebinding Complete!"))
            .Start();
    }

    public void RebindNextPrefab()
    {
        inputActions.Player.nextPrefab.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnComplete(operation => Debug.Log("Rebinding Complete!"))
            .Start();
    }

    public void RebindPrevPrefab()
    {
        inputActions.Player.prevPrefab.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnComplete(operation => Debug.Log("Rebinding Complete!"))
            .Start();
    }
}
