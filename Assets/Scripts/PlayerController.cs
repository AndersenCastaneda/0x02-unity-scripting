using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private Movement _movement;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Start()
    {
        _input = new PlayerInput();
        _movement = new Movement(_rigidbody, _input);
    }

    private void Update() => _input.ReadInput();

    private void FixedUpdate() => _movement.Tick(speed, Time.fixedDeltaTime);
}
