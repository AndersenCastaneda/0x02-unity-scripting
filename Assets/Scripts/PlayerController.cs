﻿using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 380f;
    public int health = 5;

    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private Movement _movement;
    private int score = 0;

    public static event Action OnDead;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Start()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        _input = new PlayerInput();
        _movement = new Movement(_rigidbody, _input, speed);
    }

    private void Update() => _input.ReadInput();

    private void FixedUpdate() => _movement.Tick(Time.fixedDeltaTime);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.GetComponent<ICollectable>().Collect();
            Collect();
        }

        if (other.CompareTag("Trap"))
            TakeDamage();

        if (other.CompareTag("Goal"))
            Debug.Log("You win!");
    }

    void Collect()
    {
        ++score;
        Debug.Log($"Score: {score}");
    }

    void TakeDamage()
    {
        --health;
        Debug.Log($"Health: {health}");

        if (health == 0)
        {
            Debug.Log("Game Over!");
            OnDead?.Invoke();

            _rigidbody.drag = 2;
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }
}
