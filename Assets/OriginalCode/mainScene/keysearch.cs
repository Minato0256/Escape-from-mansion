//鍵探索フェーズの制御、視線上の鍵の色を変更
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class keysearch : MonoBehaviour
{
    //取得済みの鍵の数の変数(外部へ受け渡し)
    public static int keycount = 0;
    //探索後のドアを格納
    public GameObject door;

    //視線上のオブジェクトを格納する変数
    private GameObject preobj;
    //視線上のオブジェクトのマテリアル(変更前)を格納する変数
    private Material premate;
    //変更後のマテリアルを格納する変数
    public Material newmate;

    //ドアの角度を格納・変更
    private Quaternion doorrotation;
    //全ての鍵が拾われた後の時間の変数
    private float t;

    //「拾う」テキストオブジェクトを格納
    public GameObject key_text;

    //鍵を拾ったときの音の格納
    AudioSource audioSource;
    public AudioClip pickkey;
    // Start is called before the first frame update
    void Start()
    {
        //「拾う」メッセージの非表示
        key_text.SetActive(false);

        //開始時のドアの角度を取得
        doorrotation = door.transform.rotation;

        //audioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //マテリアルをもとに戻す(視線上なら後ろのコードで上書きする)
        if (preobj != null && premate != null)
        {
            preobj.GetComponent<MeshRenderer>().material = premate;
        }

        //rayを射出
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //rayの一定距離上に鍵があれば
            if (hit.collider.CompareTag("key") && checkTergetDis(hit.collider.gameObject))
            {
                //preobjに視線上のオブジェクトを取得
                preobj = hit.collider.gameObject;
                //premateに視線上のオブジェクトのマテリアルを取得
                premate = preobj.GetComponent<Renderer>().material;
                //視線上のオブジェクトのマテリアルを変更(上書き)
                preobj.GetComponent<MeshRenderer>().material = newmate;

                //「拾う」メッセージを表示
                key_text.SetActive(true);

                //鍵を拾ったら
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    //カウントのインクリメント
                    keycount++;
                    //「拾う：メッセージの非表示
                    preobj.SetActive(false);
                    //取得音を再生
                    audioSource.PlayOneShot(pickkey);
                }
            }
            else
                //「拾う」メッセージの非表示
                key_text.SetActive(false);
        }

        //全ての鍵が拾われ、一定時間が経過するまで
        if (keycount == 6 && t < 130f)
        {
            //時間を格納
            t += Time.deltaTime / 2;
            //ドアの角度にt(時間)を代入
            doorrotation.y = t;
            door.transform.rotation = doorrotation;
        }
    }

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
}
