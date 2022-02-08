using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;   // ������ ������Ʈ�� ��ġ�� �������

    private void OnCollisionEnter2D(Collision2D collision)  // ���� �浹�ϸ� (�÷��̾ ���������� ������)
    {
        collision.transform.position = respawnPoint.transform.position; // �浹�� ��ü�� ������ ������Ʈ�� ��ġ�� �̵�
    }
}

