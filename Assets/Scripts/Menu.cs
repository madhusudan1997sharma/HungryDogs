using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Text HighScore;

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.HasKey("HighScore"))
            HighScore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
	}
	
	public void PlayButtonClick()
    {
        SceneManager.LoadScene("gameplay");
    }
}
