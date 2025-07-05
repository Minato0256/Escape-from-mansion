//�ŏI�V�[���ł̉f���̐���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastSound : MonoBehaviour
{
    //���Ԃ��i�[����ϐ�
    private float t = 0;

    //AudioSource���i�[����ϐ�
    AudioSource audioSource;
    public AudioClip laughsound;

    //�T�E���h�Đ��t���O
    bool soundFlag = false;

    //�e�L�X�g�I�u�W�F�N�g���i�[����ϐ�
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        //�J�n���T�C�Y��0��
        this.transform.localScale = new Vector3(0, 0, 0);
        //AudioSource�̎擾
        audioSource = GetComponent<AudioSource>();
        //�{�����[����ύX
        audioSource.volume = 0.5f;
        //�u���v���b�Z�[�W�̔�\��
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ̎擾
        t += Time.deltaTime;
        //18�b��
        if(t >= 18f)
        {
            //�T�C�Y��߂�(��ʂ𕢂��Ó])
            this.transform.localScale = new Vector3(2f, 2f, 1f);
        }
        //19�b��
        if(t >= 19f && !soundFlag)
        {
            //���̍Đ�
            audioSource.PlayOneShot(laughsound);
            soundFlag = true;
        }
        //20�b��
        if(t >= 20f)
        {
            //�u���v���b�Z�[�W�̕\��
            text.SetActive(true);
        }
        //25�b��
        if(t >= 25f)
        {
            //�Q�[���I��
            Application.Quit();
        }
    }
}
