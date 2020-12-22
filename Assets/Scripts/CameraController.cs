using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Transform _target;
    private readonly float x = 1.0f;
    private readonly float y = 26.0f;
    private readonly float z = 9.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _target = player.GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x - x, y, _target.transform.position.z - z);
    }
}
