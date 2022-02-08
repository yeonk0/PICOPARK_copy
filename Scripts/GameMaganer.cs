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
        if (player.isGoal)  // 문이 열렸으면
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))  // 윗키를 눌러
            {
                GameClear();    // 게임 클리어
            }        
        }
    }

    void GameClear()
    {
        Instantiate(clearText, clearStart, Quaternion.identity); // Clear 이미지 생성
        Invoke("LoadScene", 3f);    // 3초후 씬 전환
    }
    
    void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
