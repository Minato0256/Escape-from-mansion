//�n��E�o�t�F�[�Y�̐���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ladder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //��q�ɐG�ꂽ��V�[���J��
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("ladder"))
        {
            SceneManager.LoadScene("lastScene");
        }
    }
}
