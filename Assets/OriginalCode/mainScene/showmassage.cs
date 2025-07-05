using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showmassage : MonoBehaviour
{
    public int stagecount = 0;
    public GameObject keysearchText;
    public GameObject doorText;
    public GameObject buttonsearchText;
    public GameObject exitText;

    private bool mainstageenter = false;
    private bool wellstageenter = false;

    AudioSource audioSource;
    public AudioClip doorsound;
    // Start is called before the first frame update
    void Start()
    {
        keysearchText.SetActive(true);
        doorText.SetActive(false);
        buttonsearchText.SetActive(false);
        exitText.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "mainstage")
        {
            mainstageenter = true;
        }
        if (collision.gameObject.tag == "wellstage")
        {
            wellstageenter = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch(stagecount)
        {
            case 0:
                int keycount = keysearch.keycount;
                if (keycount == 6)
                {
                    stagecount++;
                    keysearchText.SetActive(false);
                    doorText.SetActive(true);
                    audioSource.PlayOneShot(doorsound);
                }
                break;
            case 1:
                if (mainstageenter)
                {
                    stagecount++;
                    doorText.SetActive(false);
                    buttonsearchText.SetActive(true);
                }
                break;
            case 2:
                bool buttonend = buttonsearch.buttonend;
                if(buttonend)
                {
                    stagecount++;
                    buttonsearchText.SetActive(false);
                    doorText.SetActive(true);
                    audioSource.PlayOneShot(doorsound);
                }
                break;
            case 3:
                if (wellstageenter)
                {
                    stagecount++;
                    doorText.SetActive(false);
                    exitText.SetActive(true);
                }
                break;
        }     
    }
}
