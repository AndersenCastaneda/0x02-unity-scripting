using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private readonly float time = 6f;

    private void OnEnable() => PlayerController.OnDead += RestartLevel;

    private void OnDisable() => PlayerController.OnDead -= RestartLevel;

    private void RestartLevel() => StartCoroutine(LoadLevel());

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }
}
