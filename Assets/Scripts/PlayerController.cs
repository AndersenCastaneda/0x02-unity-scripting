using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
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
            Debug.Log($"Score {++score}");
            other.GetComponent<ICollectable>().Collect();
        }
    }
}
