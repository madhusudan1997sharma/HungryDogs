using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text Score, HighScore;

    // Use this for initialization
    void Start()
    {
        Score.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        HighScore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void ReplayButtonClick()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void HomeButtonClick()
    {
        SceneManager.LoadScene("menu");
    }
}
