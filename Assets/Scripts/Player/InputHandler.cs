using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private InputController _input;
    public Vector2 MovementInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    private void OnEnable()
    {
        if (_input == null)
            _input = new InputController();
        
        _input.Enable();
    }

    private void Update()
    {
        MovementInput = _input.Player.Move.ReadValue<Vector2>();
        LookInput = _input.Player.Loock.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
