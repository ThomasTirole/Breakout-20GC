using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{

    public GameObject[] blockPrefabs; // Array of blocks prefabs to choose from
    public float lateralPadding = 1.05f;
    public float verticalPadding = 0.55f;
    public int spawnCount = 15;
    public int numberOfLines;
    

    public Vector2 startPos = new Vector2(-7.35f, 4.5f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numberOfLines = blockPrefabs.Length;
        GenerateLineBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateLineBlocks()
    {
        float posX = startPos.x;
        float posY = startPos.y;


        for(int i = 0; i < numberOfLines; i++)
        {
            for(int j = 0; j < spawnCount ; j++)
            {
                Instantiate(blockPrefabs[i], new Vector2(posX, posY), Quaternion.identity);
                posX += lateralPadding;
            }
            posX = startPos.x;
            posY -= verticalPadding;
        }
        
    }
}
