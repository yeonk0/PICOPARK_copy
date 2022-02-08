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

    private void OnCollisionEnter2D(Collision2D collision)  // 엘리베이터 타면
    {
        isDown = false;     // 올라감
        StartCoroutine("elevatorUp");   // 엘리베이터 위로 올라가는 함수 실행
    }

    private void OnCollisionExit2D(Collision2D collision)   // 엘리베이터 벗어나면
    {
        isDown = true;      // 내려감
        StartCoroutine("elevatorDown");     // 엘리베이터 아래로 내려가는 함수 실행
    }  

    IEnumerator elevatorUp()    // 엘리베이터 오브젝트 위로 이동
    {
        while (!isDown)     // 올라가는 상태일때 (플레이어가 엘리베이터에 탑승)
        {
            if (isDown)     // isDown 상태 되면 올라가는것 멈춤
            {
                break;
            }
            // 도착 지점까지 이동
            transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            yield return null;
        }    
    }

    IEnumerator elevatorDown()  // 엘리베이터 오브젝트 아래로 이동
    {
        while (isDown)      // 내려가는 상태이면 (플레이어가 엘리베이터 벗어남)
        {
            // 원래 엘리베이터 지점까지 이동, 내려갈땐 조금 느리게 0.3f 곱함
            transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime * 0.3f); 
            if (transform.position == start)    // 도착하면
            {
                isDown = false;     // 내려가지 않는 상태로 표기
            }
            yield return null;
        }
    }
}
