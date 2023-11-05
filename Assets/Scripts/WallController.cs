using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x < -5)
        {
            Destroy(transform.gameObject);
        }

        transform.localPosition -= new Vector3(moveSpeed, 0, 0)  * Time.deltaTime;
    }
}
