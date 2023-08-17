using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(2000)]
public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI highScoreText;

    private string playerName;

    void Awake()
    {
        playerName = GameManager.Instance.playerName;

        inputField.text = playerName;

        highScoreText.SetText("HIGHSCORE: " + GameManager.Instance.highScore);
    }
    public void GetNameInput(string name)
    {
        playerName = name;

        GameManager.Instance.playerName = playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }    

    public void ExitGame()
    {
        GameManager.Instance.SaveInfo();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
