using UnityEngine;


public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform _lookAt;
    [SerializeField] private float _distance;
    [SerializeField][Range(0, 1)] private float _sensitivity;

    private float _xRotation;
    private float _yRotation;
    private float _minMaxRotation = 40f;
    private InputController _input;

    private void OnEnable()
    {
        if (_input == null)
            _input = new InputController();

        _input.Enable();
    }


    private void LateUpdate()
    {
        Process();
    }

    private void Process()
    {
        _xRotation += _input.Player.Loock.ReadValue<Vector2>().x * _sensitivity;//;
        _yRotation -= _input.Player.Loock.ReadValue<Vector2>().y * _sensitivity; //;
        _yRotation = Mathf.Clamp(_yRotation, -_minMaxRotation, _minMaxRotation);

        Vector3 Direction = new Vector3(0, 0, -_distance);
        Quaternion rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
        transform.position = _lookAt.position + rotation * Direction;

        transform.LookAt(_lookAt.position);
    }
}
