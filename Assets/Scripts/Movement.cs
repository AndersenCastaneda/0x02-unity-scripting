using UnityEngine;

public class Movement
{
    private readonly Rigidbody _rb;
    private readonly PlayerInput _input;
    private readonly float _yPos = 1.2f;

    public Movement(Rigidbody rigidbody, PlayerInput playerInput)
    {
        _rb = rigidbody;
        _input = playerInput;
    }

    public void Tick(float speed, float time)
    {
        _rb.AddForce(new Vector3(_input.Horizontal, _yPos, _input.Vertical) * speed * time);
    }
}
