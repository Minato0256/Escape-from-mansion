//敵のプレイヤー探索プログラム
//引用元:https://qiita.com/1225/items/697037313cf62b6b3c9d
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class search : MonoBehaviour
{
    //視野角を指定
    const float angle = 45f;

    //プレイヤーを見つけたか
    public bool phit;

    private void OnTriggerStay(Collider other)
    {
        //視界の範囲内の当たり判定
        if (other.gameObject.tag == "Player") 
        {
            //視界の角度内に収まっているか
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.forward, posDelta);

            //target_angleがangleに収まっているかどうか
            if (target_angle < angle) 
            {
                //rayの射出
                Ray ray = new Ray(this.transform.position, posDelta);
                UnityEngine.Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 0.1f);
                if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit)) //Rayを使用してtargetに当たっているか判別
                {
                    //playerにrayが当たったらphitをtrueに
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        phit = true;
                    }
                    if (hit.collider == other)
                    {
                        phit = true;
                    }
                }
            }
        }
    }
    void Update()
    {
        if (phit)
        {
            phit = false;
        }
    }
}
