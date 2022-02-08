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
        if (Input.GetKey(KeyCode.Return))   // 엔터키 입력시
        {
            SceneManager.LoadScene(nextScene);  // nextScene으로 씬전환
        }
    }
}
