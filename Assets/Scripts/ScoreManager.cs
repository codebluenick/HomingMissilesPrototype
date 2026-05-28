using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }

    public void OnButtonClick(GameObject game)
    {
        if(game.name == "restartBtn")
        {
            SceneManager.LoadScene(0);
        }
    }
}
