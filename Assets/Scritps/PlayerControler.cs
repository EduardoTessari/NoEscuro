using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 1f;
    private Vector2 _movement;
    


    private PlayerControls _playerControls;
    private Rigidbody2D _rb;

    private void Awake() 
    {
        _playerControls = new PlayerControls();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        _movement = _playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position + _movement * (_moveSpeed * Time.fixedDeltaTime));
    }


}
