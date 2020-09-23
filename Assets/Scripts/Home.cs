using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public Text GameOver;
    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = "Melhor pontuação: " + LevelManager.levelManeger.highScore;
        GameOver.gameObject.SetActive(LevelManager.levelManeger.GetIsgameOver());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
