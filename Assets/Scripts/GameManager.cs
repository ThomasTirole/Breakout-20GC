using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] bricks;
    private void Awake ()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
    }

    // Update is called once per frame
    void Update()
    {
        if (bricks.Length == 0)
        {
            SceneManager.LoadScene(0); // reload the scene
        }
    }
}
