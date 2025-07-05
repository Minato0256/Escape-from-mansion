using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverFadeout : MonoBehaviour
{
    float timer = 0;
    float alfa;
    float speed = 0.001f;
    float red, green, blue;

    public GameObject GameoverText;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        GameoverText.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1f)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
        }
        if(timer > 3f)
        {
            GameoverText.SetActive(true);
        }
        if(timer > 5f)
        {
            SceneManager.LoadScene("titleScene");
            //Application.Quit();
        }
    }
}
