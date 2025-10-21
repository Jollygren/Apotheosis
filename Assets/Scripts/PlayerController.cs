using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float _speed = 10f;
    private InputAction _moveAction;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = _moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y) * _speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
