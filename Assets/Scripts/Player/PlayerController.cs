using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();   
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _inputActions.Begin.Enable();

        _inputActions.Player.Jump.performed += OnJumpPressed;

        _inputActions.Begin.StartGame.performed += OnBegginPressed;
        _inputActions.Begin.ChangeAudio.performed += OnChangeAudioPressed;

        _inputActions.Dead.RestartGame.performed += OnRestartPressed;

        GameEvents.OnEnableDeadInput += EnableDeadInput;
    }

    private void OnDisable()
    {
        _inputActions.Player.Jump.performed -= OnJumpPressed;

        _inputActions.Begin.StartGame.performed -= OnBegginPressed;
        _inputActions.Begin.ChangeAudio.performed -= OnChangeAudioPressed;

        _inputActions.Dead.RestartGame.performed -= OnRestartPressed;

        GameEvents.OnEnableDeadInput -= EnableDeadInput;

        _inputActions.Disable();
    }

    private void OnBegginPressed(InputAction.CallbackContext context)
    {
        GameEvents.RaiseDisablePause();
        EnablePlayerInput();
    }

    private void OnChangeAudioPressed(InputAction.CallbackContext context)
    {
        GameEvents.RaiseChangeAudio();
    }

    private void OnJumpPressed(InputAction.CallbackContext context)
    {          
        _playerMover.Jump();
    }

    private void OnRestartPressed(InputAction.CallbackContext context)
    {
        GameEvents.RaiseReloadScene();
    }

    private void EnablePlayerInput()
    {
        _inputActions.Disable();
        _inputActions.Player.Enable();
    }

    private void EnableDeadInput()
    {
        _inputActions.Disable();
        _inputActions.Dead.Enable();
    }
   
}
