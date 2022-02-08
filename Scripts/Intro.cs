using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private string nextScene;
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))   // ����Ű �Է½�
        {
            SceneManager.LoadScene(nextScene);  // nextScene���� ����ȯ
        }
    }
}
