using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingPanel;

    public GameObject mainMenuPanel;

    public void Start()
    {
        loadingPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartBtn()
    {
        mainMenuPanel.SetActive(false);
        loadingPanel.SetActive(true);
        StartCoroutine(LoadLevelAsync(1));
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public TMP_Text progressText;

    private IEnumerator LoadLevelAsync(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress) * 100f;
            progressText.text = progress.ToString("F0") + "%";

            Debug.Log (progress);
            yield return null;
        }
    }
}
