using UnityEngine;

public interface ICollectable
{
    void Collect();
}


public class Coin : MonoBehaviour, ICollectable
{
    public void Collect() => Destroy(gameObject);
}
