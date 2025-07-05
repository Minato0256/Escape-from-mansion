using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastSound : MonoBehaviour
{
    public float t = 0;
    AudioSource audioSource;
    public AudioClip laughsound;
    bool flag = false;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t >= 18f)
        {
            this.transform.localScale = new Vector3(2f, 2f, 1f);
        }
        if(t >= 19f && !flag)
        {
            audioSource.PlayOneShot(laughsound);
            flag = true;
        }
        if(t >= 20f)
        {
            text.SetActive(true);
        }
        if(t >= 25f)
        {
            Application.Quit();
        }
    }
}
