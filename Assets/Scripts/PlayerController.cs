using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _jumpForce = 250f;
    private bool _isJumping = false;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private CircleCollider2D _collider;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = _moveAction.ReadValue<Vector2>() * _speed * Time.deltaTime;
        if (_jumpAction.IsPressed())
        {
            if (!_isJumping)
            {
                inputVector.y += _jumpForce * Time.deltaTime; // Add jump force
                _isJumping = true;
            }
        }
        
        _rigidbody.AddForce(inputVector, ForceMode2D.Impulse);
        if(_collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _isJumping = false; // Reset jumping state when on the ground
        }
    }
}
