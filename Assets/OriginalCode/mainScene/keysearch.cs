//���T���t�F�[�Y�̐���A������̌��̐F��ύX
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class keysearch : MonoBehaviour
{
    //�擾�ς݂̌��̐��̕ϐ�(�O���֎󂯓n��)
    public static int keycount = 0;
    //�T����̃h�A���i�[
    public GameObject door;

    //������̃I�u�W�F�N�g���i�[����ϐ�
    private GameObject preobj;
    //������̃I�u�W�F�N�g�̃}�e���A��(�ύX�O)���i�[����ϐ�
    private Material premate;
    //�ύX��̃}�e���A�����i�[����ϐ�
    public Material newmate;

    //�h�A�̊p�x���i�[�E�ύX
    private Quaternion doorrotation;
    //�S�Ă̌����E��ꂽ��̎��Ԃ̕ϐ�
    private float t;

    //�u�E���v�e�L�X�g�I�u�W�F�N�g���i�[
    public GameObject key_text;

    //�����E�����Ƃ��̉��̊i�[
    AudioSource audioSource;
    public AudioClip pickkey;
    // Start is called before the first frame update
    void Start()
    {
        //�u�E���v���b�Z�[�W�̔�\��
        key_text.SetActive(false);

        //�J�n���̃h�A�̊p�x���擾
        doorrotation = door.transform.rotation;

        //audioSource���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�}�e���A�������Ƃɖ߂�(������Ȃ���̃R�[�h�ŏ㏑������)
        if (preobj != null && premate != null)
        {
            preobj.GetComponent<MeshRenderer>().material = premate;
        }

        //ray���ˏo
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //ray�̈�苗����Ɍ��������
            if (hit.collider.CompareTag("key") && checkTergetDis(hit.collider.gameObject))
            {
                //preobj�Ɏ�����̃I�u�W�F�N�g���擾
                preobj = hit.collider.gameObject;
                //premate�Ɏ�����̃I�u�W�F�N�g�̃}�e���A�����擾
                premate = preobj.GetComponent<Renderer>().material;
                //������̃I�u�W�F�N�g�̃}�e���A����ύX(�㏑��)
                preobj.GetComponent<MeshRenderer>().material = newmate;

                //�u�E���v���b�Z�[�W��\��
                key_text.SetActive(true);

                //�����E������
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    //�J�E���g�̃C���N�������g
                    keycount++;
                    //�u�E���F���b�Z�[�W�̔�\��
                    preobj.SetActive(false);
                    //�擾�����Đ�
                    audioSource.PlayOneShot(pickkey);
                }
            }
            else
                //�u�E���v���b�Z�[�W�̔�\��
                key_text.SetActive(false);
        }

        //�S�Ă̌����E���A��莞�Ԃ��o�߂���܂�
        if (keycount == 6 && t < 130f)
        {
            //���Ԃ��i�[
            t += Time.deltaTime / 2;
            //�h�A�̊p�x��t(����)����
            doorrotation.y = t;
            door.transform.rotation = doorrotation;
        }
    }

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
}
