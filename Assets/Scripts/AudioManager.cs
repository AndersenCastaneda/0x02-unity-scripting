using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource source;

    private void Awake() => source = GetComponent<AudioSource>();

    private void OnEnable() => PlayerController.OnDead += Wasted;
    private void OnDisable() => PlayerController.OnDead -= Wasted;

    private void Wasted() => source.Play();
}
