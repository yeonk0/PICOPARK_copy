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
        // �¿� �̵�
        direction.x = Input.GetAxisRaw("Horizontal");   // ������ �Է¹���, �� -1, �� 1
        if (direction.x < 0)    // �������� �����϶�
        {
            spriteRenderer.flipX = true;    // ��������Ʈ �ø� (������ ������)
        }
        else if (direction.x > 0)   // ���������� �����϶�
        {
            spriteRenderer.flipX = false;   // ��������Ʈ �ø� ���� (�⺻�̹����� ������ �ٶ�)
        }

        // ����
        if (Input.GetKey(KeyCode.Space))    // �����̽�Ű�� ����
        {
            if (isGround)   // ���� ��� ���������� (���߿��� �������� ����)
            {
                rb2D.velocity = Vector2.zero;     // ������ ������ �� ����
                rb2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // ������ �� �ִ� ���� ����
            }         
        }

        // ���� �̵�
        transform.position += direction * speed * Time.deltaTime;   // direction�� -1 0 1�� �ٲ�� �Ϳ� ���� ������
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") // Ground �±׸� ����� (���߿� ������)
        {
            isGround = false;       // isGround�� false�� �Ͽ� ���߿����� ���� ����
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") // Ground �±׿� �浹�ϸ� (�ٽ� ���� ������)
        {
            isGround = true;    // ��������
        }

        if (collision.collider.tag == "Key")    // key �������� ������
        {
            haveKey = true;     // ���� ���� ����
        }
    }
}
