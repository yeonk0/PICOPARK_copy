using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    GameObject obstacle;

    SpriteRenderer spriteRenderer;
    Vector3 dest;
    [SerializeField]
    private float speed = 1.0f;

    private void Start()
    {
        dest = new Vector3(obstacle.transform.position.x, obstacle.transform.position.y - 3.0f, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.enabled = false;
        StartCoroutine("ObstacleDown");
    }

    IEnumerator ObstacleDown()
    {
        while (obstacle.transform.position != dest)
        {
            obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, dest, speed * Time.deltaTime);
            yield return null;
        }
    }
}
