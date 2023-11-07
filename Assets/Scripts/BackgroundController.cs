using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed = 1f;
    public float resetPostion = 10.5f;
    public float endPostion = -4.5f;

    // Update is called once per frame
    void Update()
    {
        // Reset Postion
        if (transform.localPosition.x <= endPostion)
        {
            transform.localPosition = new Vector3(resetPostion, 0f, 0f);
            return;
        }

        transform.localPosition += Vector3.left * speed * Time.deltaTime;
    }
}
