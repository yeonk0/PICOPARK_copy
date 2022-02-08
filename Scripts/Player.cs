using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float jumpPower = 5.0f;
    [SerializeField]
    private bool isGround = true;

    Vector3 direction;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;

    public bool haveKey = false;
    public bool isGoal = false;
    

    void Start()
    {
        direction = Vector2.zero;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        haveKey = false;
        
    }

    void FixedUpdate()
    {
        // 좌우 이동
        direction.x = Input.GetAxisRaw("Horizontal");   // 방향을 입력받음, 좌 -1, 우 1
        if (direction.x < 0)    // 왼쪽으로 움직일때
        {
            spriteRenderer.flipX = true;    // 스프라이트 플립 (왼쪽을 보게함)
        }
        else if (direction.x > 0)   // 오른쪽으로 움직일때
        {
            spriteRenderer.flipX = false;   // 스프라이트 플립 안함 (기본이미지가 오른쪽 바라봄)
        }

        // 점프
        if (Input.GetKey(KeyCode.Space))    // 스페이스키가 점프
        {
            if (isGround)   // 땅을 밟고 있을때에만 (공중에서 무한점프 방지)
            {
                rb2D.velocity = Vector2.zero;     // 이전에 가해진 힘 제거
                rb2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // 점프할 수 있는 힘을 가함
            }         
        }

        // 실제 이동
        transform.position += direction * speed * Time.deltaTime;   // direction이 -1 0 1로 바뀌는 것에 따라 움직임
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") // Ground 태그를 벗어나면 (공중에 있을때)
        {
            isGround = false;       // isGround를 false로 하여 공중에서의 점프 방지
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") // Ground 태그와 충돌하면 (다시 땅을 밟을때)
        {
            isGround = true;    // 점프가능
        }

        if (collision.collider.tag == "Key")    // key 아이템을 먹으면
        {
            haveKey = true;     // 골인 조건 충족
        }
    }
}
