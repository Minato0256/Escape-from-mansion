//ボタンをクリックされた時のシーン遷移
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //「GameStart」ボタンがクリックされたら
    public void OnClick()
    {
        // メインシーンへ移動
        SceneManager.LoadScene("mainScene");
    }
}
