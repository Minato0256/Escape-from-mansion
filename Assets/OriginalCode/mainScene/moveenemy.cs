//navigation���g�����G�̓����̐���
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using static UnityEngine.UI.Image;

public class moveenemy : MonoBehaviour
{
    //�v���C���[���i�[����ϐ�
    public player player;
    //navigation���i�[����ϐ�
    NavMeshAgent Enemy_Nav;
    //�`�F�C�X�����ǂ����̕ϐ�
    public bool chacing = false;
    //�`�F�C�X���̒ǉ��ړ����x(navigation���̂ł��ړ�����)
    private float chacespeed = 0.8f;//���̒l�œ�Փx����
    //�`�F�C�X���Ԃ��Ǘ�����ϐ�
    private float chacetimer = 0;
    //��`�F�C�X���̃����_���ړ���̌���ϐ�
    private int tergetrnd;

    //search�R�[�h���i�[����ϐ�
    private search search;

    //��`�F�C�X���̃����_���ړ�����i�[����ϐ�
    public GameObject Aterget;
    public GameObject Bterget;
    public GameObject Cterget;
    public GameObject Dterget;
    public GameObject Eterget;

    //�`�F�C�X���A�`�F�C�X�J�n���̉��̊i�[
    AudioSource audioSource;
    public AudioClip bgm;
    public AudioClip laugh;
    //bgm���Đ������ǂ����̕ϐ�
    private bool bgmnow;

    //�����I�u�W�F�N�g�Ƃ̋�����1f�����Ȃ�true
    bool checkTergetDis(GameObject terget)
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        if (Mathf.Sqrt((x - terget.transform.position.x) * (x - terget.transform.position.x) + (y - terget.transform.position.y) * (y - terget.transform.position.y)) < 1f)
            return true;
        else
            return false;
    }

    //���ʉ����Ǘ�����֐�
    void Sound()
    {
        //bgm�J�n��
        if (chacing && !bgmnow)
        {
            audioSource.PlayOneShot(bgm);
            audioSource.PlayOneShot(laugh);
            bgmnow = true;
        }
        //�`�F�C�X�I����
        else if (!chacing && bgmnow)
        {
            audioSource.Stop();
            bgmnow = false;
        }

        if(chacing)
            //���ʂ��w���֐��I�Ɍ���������
            audioSource.volume = Mathf.Sqrt(chacetimer) / 2f;
        else
            audioSource.volume = 1;
    }

    //enemy�̈ړ���𐧌䂷��֐�
    void Move()
    {
        //�`�F�C�X���Ȃ�
        if (chacing)
        {
            //�ړI�n���v���C���[�ɂ����ŒZ�o�H�̎擾(AI)
            Enemy_Nav.SetDestination(player.transform.position);
            //�c��`�F�C�X���Ԃ̌���
            chacetimer -= Time.deltaTime;
            //�c��`�F�C�X���Ԃ�0�ȉ��Ȃ�
            if (chacetimer <= 0)
            {
                chacetimer = 0;
                chacing = false;
                //��`�F�C�X���̃����_���ړ�����w��
                tergetrnd = Random.Range(0, 5);
            }
            //�O��chacespeed������ɐi��(�����Ă��邽��)
            this.transform.position += transform.forward * chacespeed * Time.deltaTime;
        }
        //��`�F�C�X���Ȃ�
        else
        {
            //�ړI�n�������_���ړ���ɂ����ŒZ�o�H�̎擾(AI)
            switch (tergetrnd)
            {
                case 0:
                    Enemy_Nav.SetDestination(Aterget.transform.position);
                    //���������l�ȉ��Ȃ烉���_���ړ�����Ďw��
                    if (checkTergetDis(Aterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
                case 1:
                    Enemy_Nav.SetDestination(Bterget.transform.position);
                    //���������l�ȉ��Ȃ烉���_���ړ�����Ďw��
                    if (checkTergetDis(Bterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
                case 2:
                    Enemy_Nav.SetDestination(Cterget.transform.position);
                    //���������l�ȉ��Ȃ烉���_���ړ�����Ďw��
                    if (checkTergetDis(Cterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
                case 3:
                    Enemy_Nav.SetDestination(Dterget.transform.position);
                    //���������l�ȉ��Ȃ烉���_���ړ�����Ďw��
                    if (checkTergetDis(Dterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
                case 4:
                    Enemy_Nav.SetDestination(Eterget.transform.position);
                    //���������l�ȉ��Ȃ烉���_���ړ�����Ďw��
                    if (checkTergetDis(Eterget))
                        tergetrnd = Random.Range(0, 5);
                    break;
            }

            //������Ƀv���C���[��������(search�R�[�h�ɂĐ���)
            if (search.phit)
            {
                chacing = true;
                chacetimer = 30f;
            }
        }
    }
    void Start()
    {
        //navigation���擾
        Enemy_Nav = GetComponent<NavMeshAgent>();
        //�����_���ړ�����w��
        tergetrnd = Random.Range(0, 5);
        //search�R�[�h���擾
        search = this.GetComponent<search>();
        //audioSource���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Sound();
    }
}
