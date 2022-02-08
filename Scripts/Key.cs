using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    float time = 0.5f;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine("FollowPlayer");

    }

    IEnumerator FollowPlayer()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, time * Time.deltaTime);
            yield return null;
        }
    }
}
