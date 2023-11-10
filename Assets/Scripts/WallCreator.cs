using UnityEngine;

public class WallCreator : MonoBehaviour
{
    public GameObject prefabToInstantiate;

    public int numberOfInstances;
    private float heightOfObject;
    private GameObject[] gameObjectsArray;
    private const int pixelPerUnit = 100;

    private void Start()
    {
        // Get the height of the object
        SpriteRenderer spriteRenderer = prefabToInstantiate.GetComponent<SpriteRenderer>();
        heightOfObject = spriteRenderer.sprite.rect.height / pixelPerUnit * prefabToInstantiate.transform.localScale.y;

        // Create and instantiate the gameObject
        gameObjectsArray = new GameObject[numberOfInstances];
        for (int i = 0; i < numberOfInstances; i++)
        {
            gameObjectsArray[i] = InstantiatePrefab(i);
        }
    }

    private GameObject InstantiatePrefab(int i)
    {
        float yPos = heightOfObject * i + heightOfObject / 2;
        Vector3 spawnPosition = new Vector3(0, -yPos, 0);

        GameObject gameObject = Instantiate(prefabToInstantiate, transform);
        gameObject.transform.localPosition = spawnPosition;

        return gameObject;
    }
}

// float coinYPosition = yPostion - (0.7666f * blockInstances) - (4 - highestInstances + 2.5223f) / 2;