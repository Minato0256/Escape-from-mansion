//画面のアスペクト比を固定、はみ出た分を黒塗り
//chatGPT使用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCameraSize : MonoBehaviour
{
    //アスペクト比を指定
    public float targetAspect = 16f / 9f; // 16:9

    void Start()
    {
        //実際のスクリーンのアスペクト比を取得
        float windowAspect = (float)Screen.width / (float)Screen.height;
        //実際のアスペクト比と指定したアスペクト比の比を取る
        float scaleHeight = windowAspect / targetAspect;

        //カメラオブジェクトを取得
        Camera camera = GetComponent<Camera>();

        //縦に大きければ
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        //横に大きければ
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}
