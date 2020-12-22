using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 5;

    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private Movement _movement;
    private int score = 0;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Start()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        _input = new PlayerInput();
        _movement = new Movement(_rigidbody, _input);
    }

    private void Update() => _input.ReadInput();

    private void FixedUpdate() => _movement.Tick(speed, Time.fixedDeltaTime);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.GetComponent<ICollectable>().Collect();
            ++score;
            Debug.Log($"Score: {score}");
        }

        if (other.CompareTag("Trap"))
        {
            --health;
            Debug.Log($"Health: {health}");
        }
    }
}
