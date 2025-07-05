//gameoverSceneでtitleSceneへのフェードアウト処理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverFadeout : MonoBehaviour
{
    //時間を格納する変数
    float timer = 0;
    
    //画面のα値(不透明度)
    float alfa;

    //暗転スピード
    float speed = 0.001f;

    //画面のRGB値
    float red, green, blue;

    //テキストオブジェクトを格納する変数
    public GameObject GameoverText;

    void Start()
    {
        //RGB値を取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        
        //「ゲームオーバー」テキストの非表示
        GameoverText.SetActive(false);
    }

    void Update()
    {
        //時間の取得
        timer += Time.deltaTime;
        //1秒後
        if(timer > 1f)
        {
            //RGB値はそのままα値だけ変更
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            //α値を増加
            alfa += speed;
        }
        //3秒後
        if(timer > 3f)
        {
            //「ゲームオーバー」テキストを表示
            GameoverText.SetActive(true);
        }
        //5秒後
        if(timer > 5f)
        {
            //titleSceneへ遷移
            SceneManager.LoadScene("titleScene");
            //Application.Quit();
        }
    }
}
