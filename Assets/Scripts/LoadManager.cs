using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private readonly float time = 0.5f;

    private void OnEnable() => PlayerController.onDead += RestartLevel;

    private void OnDisable() => PlayerController.onDead -= RestartLevel;

    private void RestartLevel() => StartCoroutine(LoadLevel());

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }
}
