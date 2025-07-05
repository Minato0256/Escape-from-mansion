//現在のステージでやることをテキストで表示
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showmassage : MonoBehaviour
{
    //現在のステージ数
    private int stagecount = 0;

    //各テキストオブジェクトを格納する変数
    public GameObject keysearchText;
    public GameObject doorText;
    public GameObject buttonsearchText;
    public GameObject exitText;

    //石のドアを超え別ステージに移動したか
    private bool mainstageenter = false;
    private bool wellstageenter = false;

    //AudioSourceを格納する変数
    AudioSource audioSource;
    public AudioClip doorsound;
    // Start is called before the first frame update
    void Start()
    {
        //最初のテキストを表示、それ以外を非表示
        keysearchText.SetActive(true);
        doorText.SetActive(false);
        buttonsearchText.SetActive(false);
        exitText.SetActive(false);

        //AudioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //石のドアを超えたら
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
        //ステージ数に応じて表示するメッセージを変更
        switch(stagecount)
        {
            //鍵探索フェーズ
            case 0:
                //keysearchコードのkeycount変数を取得(拾った数)
                int keycount = keysearch.keycount;
                //鍵を全て拾ったら
                if (keycount == 6)
                {
                    stagecount++;
                    keysearchText.SetActive(false);
                    doorText.SetActive(true);
                    //ドアが開く音の再生
                    audioSource.PlayOneShot(doorsound);
                }
                break;
            //石のドアを抜けるフェーズ
            case 1:
                //石のドアを超えたら
                if (mainstageenter)
                {
                    stagecount++;
                    doorText.SetActive(false);
                    buttonsearchText.SetActive(true);
                }
                break;
            //ボタン探索フェーズ
            case 2:
                //buttonsearchコードのbuttonend変数を取得(全て押したらtrue)
                bool buttonend = buttonsearch.buttonend;
                //ボタンを全て押したら
                if(buttonend)
                {
                    stagecount++;
                    buttonsearchText.SetActive(false);
                    doorText.SetActive(true);
                    //ドアが開く音の再生
                    audioSource.PlayOneShot(doorsound);
                }
                break;
            //石のドアを抜けるフェーズ
            case 3:
                //石のドアを超えたら
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
