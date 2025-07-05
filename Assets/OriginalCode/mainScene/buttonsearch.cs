//mainScene内のボタン探索フェーズの制御、ボタンの色の変更
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsearch : MonoBehaviour
{
    //押されているかの変数(trueなら押されている)
    private bool setbutton1;
    private bool setbutton2;
    private bool setbutton3;
    private bool setbutton4;
    private bool setbutton5;
    //ボタンオブジェクトを格納
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    //全てのボタンが押されたらtrue(外部へ受け渡し)
    public static bool buttonend = false;

    //全てのボタンが押された後に開くドアを格納
    public GameObject door;

    //ドアの角度を格納・変更
    private Quaternion doorrotation;
    //全てのボタンが押された後の時間の変数
    private float t;

    //「押す」テキストオブジェクトを格納
    public GameObject button_text;

    //ボタンを押したときの音の格納
    AudioSource audioSource;
    public AudioClip pushbutton;
    // Start is called before the first frame update
    void Start()
    {
        //全てのボタンを緑色に変える
        button1.GetComponent<Renderer>().material.color = Color.green;
        button2.GetComponent<Renderer>().material.color = Color.green;
        button3.GetComponent<Renderer>().material.color = Color.green;
        button4.GetComponent<Renderer>().material.color = Color.green;
        button5.GetComponent<Renderer>().material.color = Color.green;

        //開始時のドアの角度を取得
        doorrotation = door.transform.rotation;

        //audioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //rayを射出
        Ray ray = new Ray(this.transform.position, transform.forward);
        //UnityEngine.Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 0.1f);
        if (Physics.Raycast(this.transform.position, transform.forward, out RaycastHit hit))
        {
            //rayの一定距離上にボタン1があれば
            if (hit.collider.gameObject.tag == "button1" && !setbutton1 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button1, setbutton1);
            }
            //rayの一定距離上にボタン2があれば
            else if (hit.collider.gameObject.tag == "button2" && !setbutton2 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button2, setbutton2);
            }
            //rayの一定距離上にボタン3があれば
            else if (hit.collider.gameObject.tag == "button3" && !setbutton3 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button3, setbutton3);
            }
            //rayの一定距離上にボタン4があれば
            else if (hit.collider.gameObject.tag == "button4" && !setbutton4 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button4, setbutton4);
            }
            //rayの一定距離上にボタン5があれば
            else if (hit.collider.gameObject.tag == "button5" && !setbutton5 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button5, setbutton5);
            }
            else
                //「押す」メッセージの非表示
                button_text.SetActive(false);
        }

        //全てのボタンが押されたら
        if (!buttonend && setbutton1 && setbutton2 && setbutton3 && setbutton4 && setbutton5)
            buttonend = true;

        //全てのボタンが押され、一定時間が経過するまで
        if (buttonend && t < 130f)
        {
            //時間を格納
            t += Time.deltaTime / 10;
            //ドアの角度にt(時間)を代入
            doorrotation.y = t;
            door.transform.rotation = doorrotation;
        }
    }

    //引数オブジェクトとの距離が0.5f未満ならtrue
    bool checkTergetDis(GameObject terget)
    {
        const float dist = 0.5f;
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        if (Mathf.Sqrt((x - terget.transform.position.x)* (x - terget.transform.position.x) + (y - terget.transform.position.y)* (y - terget.transform.position.y)) < dist)
            return true;
        else
            return false;
    }

    //ボタンがray上にあるときの処理
    void ButtonOnRay(GameObject button, bool setbutton)
    {
        //「押す」メッセージの表示
        button_text.SetActive(true);
        //ボタンが押されたら
        if (Input.GetMouseButtonDown(0))
        {
            //ボタンを赤色に変える
            button.GetComponent<Renderer>().material.color = Color.red;
            setbutton = true;
            //プッシュ音を再生
            audioSource.PlayOneShot(pushbutton);
        }
    }
}
