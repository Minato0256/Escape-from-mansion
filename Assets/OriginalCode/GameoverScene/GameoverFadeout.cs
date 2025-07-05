//gameoverScene��titleScene�ւ̃t�F�[�h�A�E�g����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverFadeout : MonoBehaviour
{
    //���Ԃ��i�[����ϐ�
    float timer = 0;
    
    //��ʂ̃��l(�s�����x)
    float alfa;

    //�Ó]�X�s�[�h
    float speed = 0.001f;

    //��ʂ�RGB�l
    float red, green, blue;

    //�e�L�X�g�I�u�W�F�N�g���i�[����ϐ�
    public GameObject GameoverText;

    void Start()
    {
        //RGB�l���擾
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        
        //�u�Q�[���I�[�o�[�v�e�L�X�g�̔�\��
        GameoverText.SetActive(false);
    }

    void Update()
    {
        //���Ԃ̎擾
        timer += Time.deltaTime;
        //1�b��
        if(timer > 1f)
        {
            //RGB�l�͂��̂܂܃��l�����ύX
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            //���l�𑝉�
            alfa += speed;
        }
        //3�b��
        if(timer > 3f)
        {
            //�u�Q�[���I�[�o�[�v�e�L�X�g��\��
            GameoverText.SetActive(true);
        }
        //5�b��
        if(timer > 5f)
        {
            //titleScene�֑J��
            SceneManager.LoadScene("titleScene");
            //Application.Quit();
        }
    }
}
