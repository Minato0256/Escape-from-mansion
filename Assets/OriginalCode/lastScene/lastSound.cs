//最終シーンでの映像の制御
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastSound : MonoBehaviour
{
    //時間を格納する変数
    private float t = 0;

    //AudioSourceを格納する変数
    AudioSource audioSource;
    public AudioClip laughsound;

    //サウンド再生フラグ
    bool soundFlag = false;

    //テキストオブジェクトを格納する変数
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        //開始時サイズを0に
        this.transform.localScale = new Vector3(0, 0, 0);
        //AudioSourceの取得
        audioSource = GetComponent<AudioSource>();
        //ボリュームを変更
        audioSource.volume = 0.5f;
        //「完」メッセージの非表示
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //時間の取得
        t += Time.deltaTime;
        //18秒後
        if(t >= 18f)
        {
            //サイズを戻す(画面を覆い暗転)
            this.transform.localScale = new Vector3(2f, 2f, 1f);
        }
        //19秒後
        if(t >= 19f && !soundFlag)
        {
            //音の再生
            audioSource.PlayOneShot(laughsound);
            soundFlag = true;
        }
        //20秒後
        if(t >= 20f)
        {
            //「完」メッセージの表示
            text.SetActive(true);
        }
        //25秒後
        if(t >= 25f)
        {
            //ゲーム終了
            Application.Quit();
        }
    }
}
