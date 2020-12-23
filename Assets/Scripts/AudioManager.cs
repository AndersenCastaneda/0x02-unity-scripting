using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private AudioSource audioDamage;
    [SerializeField] private AudioSource audioCoin;
#pragma warning restore 0649

    public AudioClip[] clips;

    private void OnEnable()
    {
        PlayerController.OnDead += Wasted;
        PlayerController.OnDamage += Damage;
        PlayerController.OnCollect += Collect;
    }

    private void OnDisable()
    {
        PlayerController.OnDead -= Wasted;
        PlayerController.OnDamage -= Damage;
        PlayerController.OnCollect -= Collect;
    }

    private void Wasted()
    {
        audioDamage.clip = clips[0];
        audioDamage.Play();
    }

    private void Damage()
    {
        audioDamage.clip = clips[1];
        audioDamage.time = 0.4f;
        audioDamage.Play();
    }

    private void Collect()
    {
        audioCoin.time = 0.1f;
        audioCoin.Play();
    }
}
