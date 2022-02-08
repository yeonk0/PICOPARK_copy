using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMove : MonoBehaviour
{
    Vector3 clearDest;
    // Start is called before the first frame update
    void Start()
    {
        clearDest = new Vector3(33, 12, 0);
        StartCoroutine("Move");
        
    }

    IEnumerator Move()
    {
        while (transform.position != clearDest)
        {
            transform.position = Vector3.MoveTowards(transform.position, clearDest, 5.0f * Time.deltaTime);
            yield return null;
        }
    }
}
