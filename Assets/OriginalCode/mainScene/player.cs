using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    public float speed = 3f;
    private bool gameover = false;
    public float phygaugevalue;
    public float timer;
    public Slider phyGauge;
    public bool Spacenow;
    public bool bdush;

    AudioSource audioSource;
    private bool csound;
    private bool soundnow;
    // Start is called before the first frame update
    void Start()
    {
        phygaugevalue = 5f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ChSlider();
        Sound();
    }

    void MovePlayer()
    {
        if (!gameover)
        {
            bool w = false, a = false, s = false, d = false;
            float root2;
            if (Input.GetKey(KeyCode.W))
                w = true;
            if (Input.GetKey(KeyCode.A))
                a = true;
            if (Input.GetKey(KeyCode.S))
                s = true;
            if (Input.GetKey(KeyCode.D))
                d = true;
            if (w && !s)
            {
                root2 = 1;
                if (a && !d)
                {
                    root2 = 1.414f;
                    this.transform.position -= transform.right * (speed / root2) * Time.deltaTime;
                }
                if (!a && d)
                {
                    root2 = 1.414f;
                    this.transform.position += transform.right * (speed / root2) * Time.deltaTime;
                }
                this.transform.position += transform.forward * (speed / root2) * Time.deltaTime;
            }
            else if (!w && s)
            {
                root2 = 1;
                if (a && !d)
                {
                    root2 = 1.414f;
                    this.transform.position -= transform.right * (speed / root2) * Time.deltaTime;
                }
                if (!a && d)
                {
                    root2 = 1.414f;
                    this.transform.position += transform.right * (speed / root2) * Time.deltaTime;
                }
                this.transform.position -= transform.forward * (speed / root2) * Time.deltaTime;
            }
            else if (a && !d)
                this.transform.position -= transform.right * speed * Time.deltaTime;
            else if (!a && d)
                this.transform.position += transform.right * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.Space))
                Spacenow = true;
            else
                Spacenow = false;
            if (Spacenow && bdush && phygaugevalue > 0)
            {
                speed = 5f;
                timer = 3f;
                phygaugevalue -= Time.deltaTime;

                csound = true;
            }
            else
            {
                speed = 3f;
                if (Spacenow)
                    bdush = false;
                else
                    bdush = true;

                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else if (phygaugevalue < 5f)
                    phygaugevalue += Time.deltaTime;

                csound = false;
            }
        }
    }
    void Sound()
    {
        if(csound && !soundnow)
        {
            soundnow = true;
            audioSource.Play();
        }
        if(!csound && soundnow)
        {
            soundnow = false;
            audioSource.Stop();
        }
    }
    private void ChSlider()
    {
        phyGauge.minValue = 0;
        phyGauge.maxValue = 5;
        phyGauge.value = phygaugevalue;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
            gameover = true;
    }
}
