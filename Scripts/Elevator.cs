using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]    
    float speed = 5.0f;
    [SerializeField]
    bool isDown = false;
    Vector3 start;
    Vector3 dest;

    private void Start()
    {
        start = new Vector3(transform.position.x, transform.position.y, 0);
        dest = new Vector3(transform.position.x, transform.position.y + 7.0f, 0);       
    }

    private void OnCollisionEnter2D(Collision2D collision)  // ���������� Ÿ��
    {
        isDown = false;     // �ö�
        StartCoroutine("elevatorUp");   // ���������� ���� �ö󰡴� �Լ� ����
    }

    private void OnCollisionExit2D(Collision2D collision)   // ���������� �����
    {
        isDown = true;      // ������
        StartCoroutine("elevatorDown");     // ���������� �Ʒ��� �������� �Լ� ����
    }  

    IEnumerator elevatorUp()    // ���������� ������Ʈ ���� �̵�
    {
        while (!isDown)     // �ö󰡴� �����϶� (�÷��̾ ���������Ϳ� ž��)
        {
            if (isDown)     // isDown ���� �Ǹ� �ö󰡴°� ����
            {
                break;
            }
            // ���� �������� �̵�
            transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            yield return null;
        }    
    }

    IEnumerator elevatorDown()  // ���������� ������Ʈ �Ʒ��� �̵�
    {
        while (isDown)      // �������� �����̸� (�÷��̾ ���������� ���)
        {
            // ���� ���������� �������� �̵�, �������� ���� ������ 0.3f ����
            transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime * 0.3f); 
            if (transform.position == start)    // �����ϸ�
            {
                isDown = false;     // �������� �ʴ� ���·� ǥ��
            }
            yield return null;
        }
    }
}
