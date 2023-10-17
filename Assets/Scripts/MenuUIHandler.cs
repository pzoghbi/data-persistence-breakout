using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI highscoreText;

    void Start()
    {
        if (HighscoreManager.Instance.highscore > 0)
        {
            highscoreText.text = "High score: " +
                HighscoreManager.Instance.playerName + ": " +
                HighscoreManager.Instance.highscore.ToString();
        }
    }

    public void StartNew()
    {
        if (playerNameInput.text == string.Empty)
        {
            return;
        }

        HighscoreManager.Instance.newPlayerName = playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
