using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour {

    public static int score;
    public Text scoreText;
    public Image[] healthImage;
    public Sprite dog_mouth_open, dog_mouth_close;
    public static int health;

	// Use this for initialization
	void Start () {
        score = 0;
        health = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch[] touches = Input.touches;
            foreach(Touch t in touches)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(t.position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                Collider2D hit = Physics2D.OverlapPoint(touchPos);

                if (hit && hit == gameObject.GetComponent<Collider2D>())
                {
                    gameObject.tag = "dog_mouth_open";
                    gameObject.GetComponent<SpriteRenderer>().sprite = dog_mouth_open;
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            gameObject.tag = "dog_mouth_close";
            gameObject.GetComponent<SpriteRenderer>().sprite = dog_mouth_close;
        }


        if (Dog.health < 1)
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("gameover");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "dog_mouth_open")
        {
            if (other.gameObject.tag == "bone")
            {
                Dog.score += 1;
                scoreText.GetComponent<Text>().text = Dog.score.ToString();
            }
            else if (other.gameObject.tag == "bomb")
            {
                health -= 1;
                healthImage[health].GetComponent<Image>().enabled = false;
            }
            Destroy(other.gameObject);
        }
    }
}
