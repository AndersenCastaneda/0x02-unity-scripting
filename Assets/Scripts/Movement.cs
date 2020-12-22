using UnityEngine;

public class Movement
{
    private readonly Rigidbody _rb;
    private readonly PlayerInput _input;
    private readonly float _speed;
    private readonly float _yPos = 1.2f;

    public Movement(Rigidbody rigidbody, PlayerInput playerInput, float speed)
    {
        _rb = rigidbody;
        _input = playerInput;
        _speed = speed;
    }

    public void Tick(float time)
    {
        _rb.AddForce(new Vector3(_input.Horizontal, _yPos, _input.Vertical) * _speed * time);
    }
}
