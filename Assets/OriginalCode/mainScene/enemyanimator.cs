//enemy�̃A�j���[�V�����𐧌�A�Q�[���I�[�o�[����
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyanimator : MonoBehaviour
{
    //�A�j���[�^�[���i�[����ϐ�
    private Animator anim = null;
    //�������g(enemy)
    public GameObject Tenemy;
    //moveenemy�R�[�h���i�[����ϐ�
    private moveenemy moveenemy;
    //�`�F�C�X�����A�U������
    private bool chacing,attack;

    // Start is called before the first frame update
    void Start()
    {
        //Animator���擾
        anim = GetComponent<Animator>();
        //moveenemy�R�[�h���擾
        moveenemy = Tenemy.GetComponent<moveenemy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //moveenemy�R�[�h����chacing�ϐ����擾
        chacing = moveenemy.chacing;
        //�U������������
        if (attack)
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", true);
        }
        //�`�F�C�X����������
        else if (chacing)
        {
            anim.SetBool("attack", false);
            anim.SetBool("run", true);
        }
        //����ȊO(�ʏ펞)
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", false);
        }
        //�V�[���J��(�Q�[���I�[�o�[)
        if(attack)
        {
            SceneManager.LoadScene("gameoverScene");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        attack = false;
        //�v���C���[�ɐG�ꂽ��attack��true��
        if (collision.gameObject.tag == "Player")
        {
            attack = true;
        }
    }
}
