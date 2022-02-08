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
            spriteRenderer.enabled = false;      // 닫힌 문 이미지 숨김
            player.isGoal = true;               // 클리어 조건 만족
            boxCollider.enabled = false;       // 지나갈수 있도록 비활성화
        }
    }
}
