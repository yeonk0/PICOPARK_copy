using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (player.haveKey)
        {
            spriteRenderer.enabled = false;      // ���� �� �̹��� ����
            player.isGoal = true;               // Ŭ���� ���� ����
            boxCollider.enabled = false;       // �������� �ֵ��� ��Ȱ��ȭ
        }
    }
}
