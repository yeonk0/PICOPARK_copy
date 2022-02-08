using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;   // 리스폰 오브젝트의 위치를 얻기위해

    private void OnCollisionEnter2D(Collision2D collision)  // 무언가 충돌하면 (플레이어가 낙사지점에 닿으면)
    {
        collision.transform.position = respawnPoint.transform.position; // 충돌한 물체를 리스폰 오브젝트의 위치로 이동
    }
}

