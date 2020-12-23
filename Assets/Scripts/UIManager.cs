using UnityEngine;

public class UIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject wastedImage;
#pragma warning restore 0649

    private void OnEnable() => PlayerController.OnDead += Wasted;

    private void OnDisable() => PlayerController.OnDead -= Wasted;

    private void Wasted() => wastedImage.SetActive(true);
}
