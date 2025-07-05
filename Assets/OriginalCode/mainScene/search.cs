//�G�̃v���C���[�T���v���O����
//���p��:https://qiita.com/1225/items/697037313cf62b6b3c9d
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class search : MonoBehaviour
{
    //����p���w��
    const float angle = 45f;

    //�v���C���[����������
    public bool phit;

    private void OnTriggerStay(Collider other)
    {
        //���E�͈͓̔��̓����蔻��
        if (other.gameObject.tag == "Player") 
        {
            //���E�̊p�x���Ɏ��܂��Ă��邩
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.forward, posDelta);

            //target_angle��angle�Ɏ��܂��Ă��邩�ǂ���
            if (target_angle < angle) 
            {
                //ray�̎ˏo
                Ray ray = new Ray(this.transform.position, posDelta);
                UnityEngine.Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 0.1f);
                if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit)) //Ray���g�p����target�ɓ������Ă��邩����
                {
                    //player��ray������������phit��true��
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        phit = true;
                    }
                    if (hit.collider == other)
                    {
                        phit = true;
                    }
                }
            }
        }
    }
    void Update()
    {
        if (phit)
        {
            phit = false;
        }
    }
}
