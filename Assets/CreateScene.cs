using UnityEngine;

public class CreateScene : MonoBehaviour
{
    public int forestSize;
    public int pyramidGrid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateGround();
        CreateForest();
        CreatePyramid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateGround()
    {
        Vector3 groundPos = new Vector3(0, 0, 0);
        Vector3 groundScale = new Vector3(5, 1, 5);

        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";

        ground.transform.position = groundPos;
        ground.transform.localScale = groundScale;
    }

    void CreateForest()
    {
        GameObject forest = new GameObject();
        forest.name = "Forest";

        for (int i = 0; i < forestSize; i++)
        {
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tree.name = "Tree";

            Vector3 treePos = new Vector3(Random.Range(2f, 15f), 0, Random.Range(2f, 15f));
            Vector3 treeScale = new Vector3(Random.Range(0.8f, 3.2f), Random.Range(1.5f, 6f), Random.Range(0.8f, 3.2f));

            tree.transform.position = treePos;
            tree.transform.localScale = treeScale;
            tree.transform.SetParent(forest.transform);
        }
    }

    void CreatePyramid()
    {
        GameObject pyramid = new GameObject();
        pyramid.name = "Pyramid";

        for (int layer = 0; layer < pyramidGrid; layer++)
        {
            int currentSize = pyramidGrid - layer;

            float offset = layer * 0.5f;

            for (int x = 0; x < currentSize; x++)
            {
                for (int z = 0; z < currentSize; z++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    float xPos = x - (pyramidGrid / 2f) + offset - (pyramidGrid / 2);
                    float yPos = layer + 0.5f;
                    float zPos = z - (pyramidGrid / 2f) + offset - (pyramidGrid / 2);

                    cube.transform.position = new Vector3(xPos, yPos, zPos);
                    cube.transform.localScale = new Vector3(0.9f, 1f, 0.9f);

                    cube.transform.SetParent(pyramid.transform);
                }
            }
        }
    }

    void CelestialObject()
    {
        Light light = FindFirstObjectByType<Light>();

        GameObject pivot = new GameObject("Pivot");
        pivot.transform.position = new Vector3(0, 0, 0);
    }
}
