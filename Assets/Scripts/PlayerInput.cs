using UnityEngine;

public class PlayerInput
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public void ReadInput()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }
}
