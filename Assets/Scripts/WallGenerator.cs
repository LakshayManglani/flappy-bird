using System.Collections;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject blockPrefab;
    public float moveSpeed = 2f;
    public float yPostion = 2.5f;
    public float interval = 2.0f;

    private int highestInstances;
    private int blockInstances;
    private WaitForSeconds waitTime;

    private void Start()
    {
        waitTime = new WaitForSeconds(interval);
        StartCoroutine(CreateWallAtIntervals());
    }

    IEnumerator CreateWallAtIntervals()
    {
        while (true) // Infinite loop to keep displaying the object.
        {
            highestInstances = Random.Range(3, 5);
            blockInstances = Random.Range(1, highestInstances + 1);
            CreateWall(yPostion, blockInstances);
            CreateWall(-yPostion, highestInstances - blockInstances);
            waitTime = new WaitForSeconds(Random.Range(1.3f, interval));

            // Wait for the specified interval.
            yield return waitTime;
        }
    }

    private void CreateWall(float yPos, int blockNumber)
    {
        Vector3 spawnPosition = transform.localPosition + new Vector3(0, yPos, 0);
        GameObject gameObject = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);

        if (yPos < 0)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -180));
        }

        WallCreator wallCreator = gameObject.GetComponent<WallCreator>();
        wallCreator.prefabToInstantiate = blockPrefab;
        wallCreator.numberOfInstances = blockNumber;

        WallController wallController = gameObject.GetComponent<WallController>();
        wallController.moveSpeed = moveSpeed;
    }
}