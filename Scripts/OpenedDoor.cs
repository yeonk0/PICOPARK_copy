using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedDoor : MonoBehaviour
{
    [SerializeField] private Player player;
    BoxCollider2D boxCollider2D;
    [SerializeField]
    private GameObject clear;
    Vector3 clearStart;
    Vector3 clearDest;

    void Start()
    {
        clearStart = new Vector3(25, 13, 0);
        clearDest = new Vector3(35, 13, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;  // �ݶ��̴� ��Ȱ��ȭ
        player.isGoal = true;           // ���� ���� ����
        Instantiate(clear, clearStart, Quaternion.identity);
    }
}
