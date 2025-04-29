using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour{
    public static IWeapon CurrentWeapon {  get; set; }
    public void SetWeapon(IWeapon weapon) => CurrentWeapon = weapon;
    private InputSystem_Actions _inputActions;
    private Vector2 _touchPos;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.TouchPos.performed += ctx => _touchPos = ctx.ReadValue<Vector2>();
        _inputActions.Player.Fire.started += ctx =>
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(_touchPos);
            CurrentWeapon?.OnPointerDown(worldPos); 
        };
        _inputActions.Player.Fire.canceled += ctx =>
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(_touchPos);
            CurrentWeapon?.OnPointerUp(worldPos);
        };
        _inputActions.Enable();
    }
    private void OnDestroy() => _inputActions.Disable();
    private void OnEnable() => _inputActions.Enable();
}
