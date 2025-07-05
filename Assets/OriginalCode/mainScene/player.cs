//プレイヤーの基本動作の制御
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    //定数
    //歩く速さ、走る速さ
    const float WALKSPEED = 3f;
    const float DASHSPEED = 5f;

    //体力ゲージの最大値
    const float MAXPHYGAUGE = 5f;

    //ルート2の値(斜め移動用)
    const float ROOT2 = 1.414f;

    //移動速度の格納
    private float speed;

    private float decspeed;
    //ゲームオーバーでない(プレイ中)ならfalse
    private bool gameover = false;
    //ダッシュの体力ゲージの管理
    private float phygaugevalue;
    //ダッシュ後の体力ゲージ回復クールタイム
    private float timer;
    //体力ゲージオブジェクトの格納
    public Slider phyGauge;
    //スペースキーを入力中か
    private bool Spacenow;
    //ダッシュ可能か
    private bool bdush;

    //AudioSourceの格納
    AudioSource audioSource;
    //サウンド再生するか
    private bool csound;
    //サウンド再生中か
    private bool soundnow;
    // Start is called before the first frame update
    void Start()
    {
        //speedの値を歩く速さに
        speed = WALKSPEED;
        //体力ゲージを5fに
        phygaugevalue = MAXPHYGAUGE;
        //AudioSourceの取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ChSlider();
        Sound();
    }

    //プレイヤーの動きの制御関数
    void MovePlayer()
    {
        //ゲームオーバーでないなら
        if (!gameover)
        {
            //wasdが押されているか
            bool w = false, a = false, s = false, d = false;
            //斜めに移動しているなら速度をルート2で割る、それ以外なら1で割る(そのまま)
            decspeed = 1;
            if (Input.GetKey(KeyCode.W))
                w = true;
            if (Input.GetKey(KeyCode.A))
                a = true;
            if (Input.GetKey(KeyCode.S))
                s = true;
            if (Input.GetKey(KeyCode.D))
                d = true;
            //前のみ入力しているとき(左右は考慮せず)
            if (w && !s)
            {
                //左斜め前入力
                if (a && !d)
                {
                    decspeed = ROOT2;
                    //左に移動
                    this.transform.position -= transform.right * (speed / decspeed) * Time.deltaTime;
                }
                //右斜め前入力
                if (!a && d)
                {
                    decspeed = ROOT2;
                    //右に移動
                    this.transform.position += transform.right * (speed / decspeed) * Time.deltaTime;
                }
                //前に移動
                this.transform.position += transform.forward * (speed / decspeed) * Time.deltaTime;
            }
            //後ろのみ入力しているとき(左右は考慮せず)
            else if (!w && s)
            {
                //左斜め後ろ入力
                if (a && !d)
                {
                    decspeed = ROOT2;
                    //左に移動
                    this.transform.position -= transform.right * (speed / decspeed) * Time.deltaTime;
                }
                //右斜め後ろ入力
                if (!a && d)
                {
                    decspeed = ROOT2;
                    //右に移動
                    this.transform.position += transform.right * (speed / decspeed) * Time.deltaTime;
                }
                //後ろに移動
                this.transform.position -= transform.forward * (speed / decspeed) * Time.deltaTime;
            }
            //左のみ入力しているとき(前後考慮する)
            else if (a && !d)
                //左に移動
                this.transform.position -= transform.right * speed * Time.deltaTime;
            //右のみ入力しているとき(前後考慮する)
            else if (!a && d)
                //右に移動
                this.transform.position += transform.right * speed * Time.deltaTime;

            //スペースキー入力中ならtrue、入力してないならfalse
            if (Input.GetKey(KeyCode.Space))
                Spacenow = true;
            else
                Spacenow = false;

            //スペースキーを押していてダッシュ中で体力が0超過なら
            if (Spacenow && bdush && phygaugevalue > 0)
            {
                //ダッシュ中の処理
                //speedの値を走る速さに
                speed = DASHSPEED;
                //体力回復までのクールタイムをリセット
                timer = 3f;
                //体力ゲージを減らす
                phygaugevalue -= Time.deltaTime;

                //音を鳴らす
                csound = true;
            }
            //ダッシュ中でないなら
            else
            {
                //speedの値を歩く速さに
                speed = WALKSPEED;

                //スペースキー長押しでも体力ゲージを回復できるように
                //phygaugevalueが0でスペースキーを押しているならbdushをfalseに
                if (Spacenow)
                    bdush = false;
                else
                    bdush = true;

                //体力ゲージ回復までのクールタイム
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                //体力ゲージ回復
                else if (phygaugevalue < 5f)
                    phygaugevalue += Time.deltaTime;

                //音の終了
                csound = false;
            }
        }
    }

    //音の再生開始・停止関数
    void Sound()
    {
        //再生開始
        if(csound && !soundnow)
        {
            soundnow = true;
            audioSource.Play();
        }
        //再生終了
        if(!csound && soundnow)
        {
            soundnow = false;
            audioSource.Stop();
        }
    }

    //体力ゲージの反映
    private void ChSlider()
    {
        phyGauge.minValue = 0;
        phyGauge.maxValue = MAXPHYGAUGE;
        phyGauge.value = phygaugevalue;
    }

    //敵に当たったらゲームオーバー(全ての処理をできなくする)
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
            gameover = true;
    }
}
