using UnityEngine;

public class Rotator : MonoBehaviour
{
    private readonly float x = 0f;
    private float y = 0f;
    private readonly float z = 90f;

    private void Update()
    {
        y += 45f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(x, y, z);
    }
}
