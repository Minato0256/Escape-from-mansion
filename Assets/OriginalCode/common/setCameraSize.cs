//��ʂ̃A�X�y�N�g����Œ�A�͂ݏo���������h��
//chatGPT�g�p
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCameraSize : MonoBehaviour
{
    //�A�X�y�N�g����w��
    public float targetAspect = 16f / 9f; // 16:9

    void Start()
    {
        //���ۂ̃X�N���[���̃A�X�y�N�g����擾
        float windowAspect = (float)Screen.width / (float)Screen.height;
        //���ۂ̃A�X�y�N�g��Ǝw�肵���A�X�y�N�g��̔�����
        float scaleHeight = windowAspect / targetAspect;

        //�J�����I�u�W�F�N�g���擾
        Camera camera = GetComponent<Camera>();

        //�c�ɑ傫�����
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        //���ɑ傫�����
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
