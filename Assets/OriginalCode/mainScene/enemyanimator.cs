//enemyのアニメーションを制御、ゲームオーバー処理
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyanimator : MonoBehaviour
{
    //アニメーターを格納する変数
    private Animator anim = null;
    //自分自身(enemy)
    public GameObject Tenemy;
    //moveenemyコードを格納する変数
    private moveenemy moveenemy;
    //チェイス中か、攻撃中か
    private bool chacing,attack;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorを取得
        anim = GetComponent<Animator>();
        //moveenemyコードを取得
        moveenemy = Tenemy.GetComponent<moveenemy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //moveenemyコードからchacing変数を取得
        chacing = moveenemy.chacing;
        //攻撃中だったら
        if (attack)
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", true);
        }
        //チェイス中だったら
        else if (chacing)
        {
            anim.SetBool("attack", false);
            anim.SetBool("run", true);
        }
        //それ以外(通常時)
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", false);
        }
        //シーン遷移(ゲームオーバー)
        if(attack)
        {
            SceneManager.LoadScene("gameoverScene");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        attack = false;
        //プレイヤーに触れたらattackをtrueに
        if (collision.gameObject.tag == "Player")
        {
            attack = true;
        }
    }
}
