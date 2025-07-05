//���݂̃X�e�[�W�ł�邱�Ƃ��e�L�X�g�ŕ\��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showmassage : MonoBehaviour
{
    //���݂̃X�e�[�W��
    private int stagecount = 0;

    //�e�e�L�X�g�I�u�W�F�N�g���i�[����ϐ�
    public GameObject keysearchText;
    public GameObject doorText;
    public GameObject buttonsearchText;
    public GameObject exitText;

    //�΂̃h�A�𒴂��ʃX�e�[�W�Ɉړ�������
    private bool mainstageenter = false;
    private bool wellstageenter = false;

    //AudioSource���i�[����ϐ�
    AudioSource audioSource;
    public AudioClip doorsound;
    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��̃e�L�X�g��\���A����ȊO���\��
        keysearchText.SetActive(true);
        doorText.SetActive(false);
        buttonsearchText.SetActive(false);
        exitText.SetActive(false);

        //AudioSource���擾
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�΂̃h�A�𒴂�����
        if(collision.gameObject.tag == "mainstage")
        {
            mainstageenter = true;
        }
        if (collision.gameObject.tag == "wellstage")
        {
            wellstageenter = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //�X�e�[�W���ɉ����ĕ\�����郁�b�Z�[�W��ύX
        switch(stagecount)
        {
            //���T���t�F�[�Y
            case 0:
                //keysearch�R�[�h��keycount�ϐ����擾(�E������)
                int keycount = keysearch.keycount;
                //����S�ďE������
                if (keycount == 6)
                {
                    stagecount++;
                    keysearchText.SetActive(false);
                    doorText.SetActive(true);
                    //�h�A���J�����̍Đ�
                    audioSource.PlayOneShot(doorsound);
                }
                break;
            //�΂̃h�A�𔲂���t�F�[�Y
            case 1:
                //�΂̃h�A�𒴂�����
                if (mainstageenter)
                {
                    stagecount++;
                    doorText.SetActive(false);
                    buttonsearchText.SetActive(true);
                }
                break;
            //�{�^���T���t�F�[�Y
            case 2:
                //buttonsearch�R�[�h��buttonend�ϐ����擾(�S�ĉ�������true)
                bool buttonend = buttonsearch.buttonend;
                //�{�^����S�ĉ�������
                if(buttonend)
                {
                    stagecount++;
                    buttonsearchText.SetActive(false);
                    doorText.SetActive(true);
                    //�h�A���J�����̍Đ�
                    audioSource.PlayOneShot(doorsound);
                }
                break;
            //�΂̃h�A�𔲂���t�F�[�Y
            case 3:
                //�΂̃h�A�𒴂�����
                if (wellstageenter)
                {
                    stagecount++;
                    doorText.SetActive(false);
                    exitText.SetActive(true);
                }
                break;
        }     
    }
}
