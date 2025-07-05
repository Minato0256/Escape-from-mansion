//mainScene���̃{�^���T���t�F�[�Y�̐���A�{�^���̐F�̕ύX
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsearch : MonoBehaviour
{
    //������Ă��邩�̕ϐ�(true�Ȃ牟����Ă���)
    private bool setbutton1;
    private bool setbutton2;
    private bool setbutton3;
    private bool setbutton4;
    private bool setbutton5;
    //�{�^���I�u�W�F�N�g���i�[
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    //�S�Ẵ{�^���������ꂽ��true(�O���֎󂯓n��)
    public static bool buttonend = false;

    //�S�Ẵ{�^���������ꂽ��ɊJ���h�A���i�[
    public GameObject door;

    //�h�A�̊p�x���i�[�E�ύX
    private Quaternion doorrotation;
    //�S�Ẵ{�^���������ꂽ��̎��Ԃ̕ϐ�
    private float t;

    //�u�����v�e�L�X�g�I�u�W�F�N�g���i�[
    public GameObject button_text;

    //�{�^�����������Ƃ��̉��̊i�[
    AudioSource audioSource;
    public AudioClip pushbutton;
    // Start is called before the first frame update
    void Start()
    {
        //�S�Ẵ{�^����ΐF�ɕς���
        button1.GetComponent<Renderer>().material.color = Color.green;
        button2.GetComponent<Renderer>().material.color = Color.green;
        button3.GetComponent<Renderer>().material.color = Color.green;
        button4.GetComponent<Renderer>().material.color = Color.green;
        button5.GetComponent<Renderer>().material.color = Color.green;

        //�J�n���̃h�A�̊p�x���擾
        doorrotation = door.transform.rotation;

        //audioSource���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ray���ˏo
        Ray ray = new Ray(this.transform.position, transform.forward);
        //UnityEngine.Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 0.1f);
        if (Physics.Raycast(this.transform.position, transform.forward, out RaycastHit hit))
        {
            //ray�̈�苗����Ƀ{�^��1�������
            if (hit.collider.gameObject.tag == "button1" && !setbutton1 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button1, setbutton1);
            }
            //ray�̈�苗����Ƀ{�^��2�������
            else if (hit.collider.gameObject.tag == "button2" && !setbutton2 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button2, setbutton2);
            }
            //ray�̈�苗����Ƀ{�^��3�������
            else if (hit.collider.gameObject.tag == "button3" && !setbutton3 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button3, setbutton3);
            }
            //ray�̈�苗����Ƀ{�^��4�������
            else if (hit.collider.gameObject.tag == "button4" && !setbutton4 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button4, setbutton4);
            }
            //ray�̈�苗����Ƀ{�^��5�������
            else if (hit.collider.gameObject.tag == "button5" && !setbutton5 && checkTergetDis(hit.collider.gameObject))
            {
                ButtonOnRay(button5, setbutton5);
            }
            else
                //�u�����v���b�Z�[�W�̔�\��
                button_text.SetActive(false);
        }

        //�S�Ẵ{�^���������ꂽ��
        if (!buttonend && setbutton1 && setbutton2 && setbutton3 && setbutton4 && setbutton5)
            buttonend = true;

        //�S�Ẵ{�^����������A��莞�Ԃ��o�߂���܂�
        if (buttonend && t < 130f)
        {
            //���Ԃ��i�[
            t += Time.deltaTime / 10;
            //�h�A�̊p�x��t(����)����
            doorrotation.y = t;
            door.transform.rotation = doorrotation;
        }
    }

    //�����I�u�W�F�N�g�Ƃ̋�����0.5f�����Ȃ�true
    bool checkTergetDis(GameObject terget)
    {
        const float dist = 0.5f;
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        if (Mathf.Sqrt((x - terget.transform.position.x)* (x - terget.transform.position.x) + (y - terget.transform.position.y)* (y - terget.transform.position.y)) < dist)
            return true;
        else
            return false;
    }

    //�{�^����ray��ɂ���Ƃ��̏���
    void ButtonOnRay(GameObject button, bool setbutton)
    {
        //�u�����v���b�Z�[�W�̕\��
        button_text.SetActive(true);
        //�{�^���������ꂽ��
        if (Input.GetMouseButtonDown(0))
        {
            //�{�^����ԐF�ɕς���
            button.GetComponent<Renderer>().material.color = Color.red;
            setbutton = true;
            //�v�b�V�������Đ�
            audioSource.PlayOneShot(pushbutton);
        }
    }
}
