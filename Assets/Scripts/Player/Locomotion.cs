using UnityEngine;

public class Locomotion : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private InputHandler _input;
    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;
    private CharacterController _characterController;
    private float _yVelocity;

    public float AmountVelocity { get; private set; }
    public bool IsMoving => AmountVelocity > 0;

    private void Start()
    {
        _input = GetComponent<InputHandler>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ProcessGravity();
        ProcessValue();
        ProcessDirectionMovement();
        ProcessRotation();

        if (Input.GetMouseButtonDown(1))// замена на jump
            if (_characterController.isGrounded)
                _yVelocity = 4f;
    }

    private void ProcessValue()
    {
        _horizontal = _input.MovementInput.x;
        _vertical = _input.MovementInput.y;
        AmountVelocity = Mathf.Clamp01(Mathf.Abs(_horizontal) + Mathf.Abs(_vertical));
    }

    private void ProcessDirectionMovement()
    {
        _direction = (_camera.forward * _vertical + _camera.right * _horizontal).normalized;
        _direction *= _speed;
        _direction.y = _yVelocity;
        _direction *= Time.deltaTime;
    }

    private void ProcessGravity()
    {
        _characterController.Move(_direction);

        if (!_characterController.isGrounded)
            _yVelocity += -9.8f * Time.deltaTime;
    }

    private void ProcessRotation()
    {
        Vector3 direction = _direction;
        direction.Normalize();
        direction.y = 0;

        if (direction == Vector3.zero)
            direction = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion currentRotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        transform.rotation = currentRotation;
    }

}
