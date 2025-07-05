//マウスカーソルを表示
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleSceneCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //カーソルの表示・ロックの解除
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
