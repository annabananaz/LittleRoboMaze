using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Text loadText;
    public float loadTime;

    private float timePercent;
    private bool loadingDone;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        loadText.text = "";
        timePercent = 0.0f;
        loadingDone = false;
    }

    void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        float timer = 0.0f;
        while(timer < loadTime)
        {
            timer += Time.deltaTime;
            float value = timer / loadTime;
            timePercent = Mathf.Lerp(0.0f, 1.0f, value);
            yield return null;
        }

    }

    private void Update()
    {
        //Debug.Log(timePercent);
        if (!loadingDone)
        {
            if (timePercent >= 1)
                loadingDone = true;
            else if (timePercent >= 0.75f)
                loadText.text = "Scene built. Loading now.";
            else if (timePercent > 0.5f)
                loadText.text = "Building program . . .";
            else if (timePercent > 0.0f)
                loadText.text = "Compiling code . . .";
        }
        else
        {

            SceneManager.LoadScene("Level1");
        }
    }
}
