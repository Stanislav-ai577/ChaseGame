using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    private Timer _timer;

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        FreezRotation();
    }
    
    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        CameraRotation();
    }
    
    private void FreezRotation()
    {
        _rigidbody.freezeRotation = true;
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * _rotationSpeed;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }

    private void Movement()
    {
        Vector3 inputMove = Vector3.zero;

        inputMove.x = Input.GetAxis("Horizontal");
        inputMove.z = Input.GetAxis("Vertical");

        inputMove *= _speed;

        Vector3 directionMove = transform.right * inputMove.x + transform.forward * inputMove.z;
        _rigidbody.velocity = new Vector3(directionMove.x, _rigidbody.velocity.y, directionMove.z);
    }
}
