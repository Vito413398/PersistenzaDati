using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI bestScoreText;
    //public Tmp_InputField 
    // Start is called before the first frame update
    void Start()
    {
        if (!String.IsNullOrEmpty(MenuManager.Instance.namePlayers))
        {
            nameInputField.text = MenuManager.Instance.namePlayers;
            startButton.gameObject.SetActive(true);
        }
        bestScoreText.text = $"Best Player : {MenuManager.Instance.nameBestScore }" + $" Score :{MenuManager.Instance.scoreBestScore.ToString()}";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartButton()
    {
        
        //SceneManager.LoadScene("Main", LoadSceneMode.Single);
        SceneManager.LoadScene(1);
    }
    public void OnExitButton()
    {
        //EditorApplication.isPlaying = false;

        // EditorApplication.isPlaying = false;

        // Application.Quit();

       //MenuManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif


    }
    public void OnNameEnter()
    {
        MenuManager.Instance.namePlayers = nameInputField.text;
        Debug.Log("Player : " + MenuManager.Instance.namePlayers);
        startButton.gameObject.SetActive(true);
    }
}
