using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        MenuManager.Instance.LoadScore();
        bestScoreText.text = $"Best score : {MenuManager.Instance.nameBestScore} " + $" Score : {MenuManager.Instance.scoreBestScore.ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
