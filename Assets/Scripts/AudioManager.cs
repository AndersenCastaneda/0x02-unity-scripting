using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[1];
    }

    private void OnEnable()
    {
        PlayerController.OnDead += Wasted;
        PlayerController.OnDamage += Damage;
    }

    private void OnDisable()
    {
        PlayerController.OnDead -= Wasted;
        PlayerController.OnDamage -= Damage;
    }

    private void Wasted()
    {
        source.clip = clips[0];
        source.Play();
    }

    private void Damage()
    {
        source.time = 0.4f;
        source.Play();
    }
}
