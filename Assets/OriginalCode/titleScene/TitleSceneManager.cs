//�{�^�����N���b�N���ꂽ���̃V�[���J��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�uGameStart�v�{�^�����N���b�N���ꂽ��
    public void OnClick()
    {
        // ���C���V�[���ֈړ�
        SceneManager.LoadScene("mainScene");
    }
}
