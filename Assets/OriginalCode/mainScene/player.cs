//�v���C���[�̊�{����̐���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    //�萔
    //���������A���鑬��
    const float WALKSPEED = 3f;
    const float DASHSPEED = 5f;

    //�̗̓Q�[�W�̍ő�l
    const float MAXPHYGAUGE = 5f;

    //���[�g2�̒l(�΂߈ړ��p)
    const float ROOT2 = 1.414f;

    //�ړ����x�̊i�[
    private float speed;

    private float decspeed;
    //�Q�[���I�[�o�[�łȂ�(�v���C��)�Ȃ�false
    private bool gameover = false;
    //�_�b�V���̗̑̓Q�[�W�̊Ǘ�
    private float phygaugevalue;
    //�_�b�V����̗̑̓Q�[�W�񕜃N�[���^�C��
    private float timer;
    //�̗̓Q�[�W�I�u�W�F�N�g�̊i�[
    public Slider phyGauge;
    //�X�y�[�X�L�[����͒���
    private bool Spacenow;
    //�_�b�V���\��
    private bool bdush;

    //AudioSource�̊i�[
    AudioSource audioSource;
    //�T�E���h�Đ����邩
    private bool csound;
    //�T�E���h�Đ�����
    private bool soundnow;
    // Start is called before the first frame update
    void Start()
    {
        //speed�̒l�����������
        speed = WALKSPEED;
        //�̗̓Q�[�W��5f��
        phygaugevalue = MAXPHYGAUGE;
        //AudioSource�̎擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ChSlider();
        Sound();
    }

    //�v���C���[�̓����̐���֐�
    void MovePlayer()
    {
        //�Q�[���I�[�o�[�łȂ��Ȃ�
        if (!gameover)
        {
            //wasd��������Ă��邩
            bool w = false, a = false, s = false, d = false;
            //�΂߂Ɉړ����Ă���Ȃ瑬�x�����[�g2�Ŋ���A����ȊO�Ȃ�1�Ŋ���(���̂܂�)
            decspeed = 1;
            if (Input.GetKey(KeyCode.W))
                w = true;
            if (Input.GetKey(KeyCode.A))
                a = true;
            if (Input.GetKey(KeyCode.S))
                s = true;
            if (Input.GetKey(KeyCode.D))
                d = true;
            //�O�̂ݓ��͂��Ă���Ƃ�(���E�͍l������)
            if (w && !s)
            {
                //���΂ߑO����
                if (a && !d)
                {
                    decspeed = ROOT2;
                    //���Ɉړ�
                    this.transform.position -= transform.right * (speed / decspeed) * Time.deltaTime;
                }
                //�E�΂ߑO����
                if (!a && d)
                {
                    decspeed = ROOT2;
                    //�E�Ɉړ�
                    this.transform.position += transform.right * (speed / decspeed) * Time.deltaTime;
                }
                //�O�Ɉړ�
                this.transform.position += transform.forward * (speed / decspeed) * Time.deltaTime;
            }
            //���̂ݓ��͂��Ă���Ƃ�(���E�͍l������)
            else if (!w && s)
            {
                //���΂ߌ�����
                if (a && !d)
                {
                    decspeed = ROOT2;
                    //���Ɉړ�
                    this.transform.position -= transform.right * (speed / decspeed) * Time.deltaTime;
                }
                //�E�΂ߌ�����
                if (!a && d)
                {
                    decspeed = ROOT2;
                    //�E�Ɉړ�
                    this.transform.position += transform.right * (speed / decspeed) * Time.deltaTime;
                }
                //���Ɉړ�
                this.transform.position -= transform.forward * (speed / decspeed) * Time.deltaTime;
            }
            //���̂ݓ��͂��Ă���Ƃ�(�O��l������)
            else if (a && !d)
                //���Ɉړ�
                this.transform.position -= transform.right * speed * Time.deltaTime;
            //�E�̂ݓ��͂��Ă���Ƃ�(�O��l������)
            else if (!a && d)
                //�E�Ɉړ�
                this.transform.position += transform.right * speed * Time.deltaTime;

            //�X�y�[�X�L�[���͒��Ȃ�true�A���͂��ĂȂ��Ȃ�false
            if (Input.GetKey(KeyCode.Space))
                Spacenow = true;
            else
                Spacenow = false;

            //�X�y�[�X�L�[�������Ă��ă_�b�V�����ő̗͂�0���߂Ȃ�
            if (Spacenow && bdush && phygaugevalue > 0)
            {
                //�_�b�V�����̏���
                //speed�̒l�𑖂鑬����
                speed = DASHSPEED;
                //�̗͉񕜂܂ł̃N�[���^�C�������Z�b�g
                timer = 3f;
                //�̗̓Q�[�W�����炷
                phygaugevalue -= Time.deltaTime;

                //����炷
                csound = true;
            }
            //�_�b�V�����łȂ��Ȃ�
            else
            {
                //speed�̒l�����������
                speed = WALKSPEED;

                //�X�y�[�X�L�[�������ł��̗̓Q�[�W���񕜂ł���悤��
                //phygaugevalue��0�ŃX�y�[�X�L�[�������Ă���Ȃ�bdush��false��
                if (Spacenow)
                    bdush = false;
                else
                    bdush = true;

                //�̗̓Q�[�W�񕜂܂ł̃N�[���^�C��
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                //�̗̓Q�[�W��
                else if (phygaugevalue < 5f)
                    phygaugevalue += Time.deltaTime;

                //���̏I��
                csound = false;
            }
        }
    }

    //���̍Đ��J�n�E��~�֐�
    void Sound()
    {
        //�Đ��J�n
        if(csound && !soundnow)
        {
            soundnow = true;
            audioSource.Play();
        }
        //�Đ��I��
        if(!csound && soundnow)
        {
            soundnow = false;
            audioSource.Stop();
        }
    }

    //�̗̓Q�[�W�̔��f
    private void ChSlider()
    {
        phyGauge.minValue = 0;
        phyGauge.maxValue = MAXPHYGAUGE;
        phyGauge.value = phygaugevalue;
    }

    //�G�ɓ���������Q�[���I�[�o�[(�S�Ă̏������ł��Ȃ�����)
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
            gameover = true;
    }
}
