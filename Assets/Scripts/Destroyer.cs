using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Destroyer : MonoBehaviour
{
    public Image[] healthImage;
    public Text timerText;
    float timer = 3.5f;
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0.5f)
            timerText.GetComponent<Text>().text = Convert.ToInt32(timer).ToString();
        else
            timerText.GetComponent<Text>().text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bone")
        {
            Dog.health -= 1;
            try
            {
                healthImage[Dog.health].GetComponent<Image>().enabled = false;
            }
            catch { }
        }
    }
}
