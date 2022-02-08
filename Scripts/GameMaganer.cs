using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaganer : MonoBehaviour
{
    [SerializeField]
    private GameObject clearText;
    Vector3 clearStart;
    [SerializeField]
    private Player player;
    [SerializeField]
    private string nextScene;
    
    void Start()
    {
        clearStart = new Vector3(25, 13, 0);
    }

    
    void Update()
    {
        if (player.isGoal)  // ���� ��������
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))  // ��Ű�� ����
            {
                GameClear();    // ���� Ŭ����
            }        
        }
    }

    void GameClear()
    {
        Instantiate(clearText, clearStart, Quaternion.identity); // Clear �̹��� ����
        Invoke("LoadScene", 3f);    // 3���� �� ��ȯ
    }
    
    void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
