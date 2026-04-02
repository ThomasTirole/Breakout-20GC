using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject[] lives;

    public static UI instance;

    private void Awake ()
    {
        instance = this;
    }

    // called when we take damage
    public void UpdateHealth (int health)
    {
        // for each heart inside the herats list
        for (int x= 0; x < lives.Length; ++x)
        {
            // activate to match the current HP
            lives[x].SetActive(x < health);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
