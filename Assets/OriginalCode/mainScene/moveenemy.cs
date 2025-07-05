//navigationを使った敵の動きの制御
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using static UnityEngine.UI.Image;

public class moveenemy : MonoBehaviour
{
    //プレイヤーを格納する変数
    public player player;
    //navigationを格納する変数
    NavMeshAgent Enemy_Nav;
    //チェイス中かどうかの変数
    public bool chacing = false;
    //チェイス中の追加移動速度(navigation自体でも移動する)
    private float chacespeed = 0.8f;//この値で難易度調整
    //チェイス時間を管理する変数
    private float chacetimer = 0;
    //非チェイス時のランダム移動先の決定変数
    private int tergetrnd;

    //searchコードを格納する変数
    private search search;

    //非チェイス時のランダム移動先を格納する変数
    public GameObject Aterget;
    public GameObject Bterget;
    public GameObject Cterget;
    public GameObject Dterget;
    public GameObject Eterget;

    //チェイス中、チェイス開始時の音の格納
    AudioSource audioSource;
    public AudioClip bgm;
    public AudioClip laugh;
    //bgmが再生中かどうかの変数
    private bool bgmnow;

    //引数オブジェクトとの距離が1f未満ならtrue
    bool checkTergetDis(GameObject terget)
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        if (Mathf.Sqrt((x - terget.transform.position.x) * (x - terget.transform.position.x) + (y - terget.transform.position.y) * (y - terget.transform.position.y)) < 1f)
            return true;
        else
            return false;
    }

    //効果音を管理する関数
    void Sound()
    {
        //bgm開始時
        if (chacing && !bgmnow)
        {
            audioSource.PlayOneShot(bgm);
            audioSource.PlayOneShot(laugh);
            bgmnow = true;
        }
        //チェイス終了時
        else if (!chacing && bgmnow)
        {
            audioSource.Stop();
            bgmnow = false;
        }

        if(chacing)
            //音量を指数関数的に減少させる
            audioSource.volume = Mathf.Sqrt(chacetimer) / 2f;
        else
            audioSource.volume = 1;
    }

    //enemyの移動先を制御する関数
    void Move()
    {
        //チェイス中なら
        if (chacing)
        {
            //目的地をプレイヤーにした最短経路の取得(AI)
            Enemy_Nav.SetDestination(player.transform.position);
            //残りチェイス時間の減少
            chacetimer -= Time.deltaTime;
            //残りチェイス時間が0以下なら
            if (chacetimer <= 0)
            {
                chacetimer = 0;
                chacing = false;
                //非チェイス時のランダム移動先を指定
                tergetrnd = Random.Range(0, 5);
            }
            //前にchacespeed分さらに進む(走っているため)
            this.transform.position += transform.forward * chacespeed * Time.deltaTime;
        }
        //非チェイス中なら
        else
        {
            //目的地をランダム移動先にした最短経路の取得(AI)
            switch (tergetrnd)
            {
                case 0:
                    Enemy_Nav.SetDestination(Aterget.transform.position);
                    //距離が一定値以下ならランダム移動先を再指定
                    if (checkTergetDis(Aterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
                case 1:
                    Enemy_Nav.SetDestination(Bterget.transform.position);
                    //距離が一定値以下ならランダム移動先を再指定
                    if (checkTergetDis(Bterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
                case 2:
                    Enemy_Nav.SetDestination(Cterget.transform.position);
                    //距離が一定値以下ならランダム移動先を再指定
                    if (checkTergetDis(Cterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
                case 3:
                    Enemy_Nav.SetDestination(Dterget.transform.position);
                    //距離が一定値以下ならランダム移動先を再指定
                    if (checkTergetDis(Dterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
                case 4:
                    Enemy_Nav.SetDestination(Eterget.transform.position);
                    //距離が一定値以下ならランダム移動先を再指定
                    if (checkTergetDis(Eterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
            }

            //視線上にプレイヤーがいたら(searchコードにて制御)
            if (search.phit)
            {
                chacing = true;
                chacetimer = 30f;
            }
        }
    }
    void Start()
    {
        //navigationを取得
        Enemy_Nav = GetComponent<NavMeshAgent>();
        //ランダム移動先を指定
        tergetrnd = Random.Range(0, 5);
        //searchコードを取得
        search = this.GetComponent<search>();
        //audioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Sound();
    }
}
