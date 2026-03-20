using System.IO.Compression;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 10f;
    private int directionY = 1;
    private Vector2 playerPos;
    private Vector2 ballPos;

    private Rigidbody2D rig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //TODO: ajouter les Tags sur les éléments du jeu
        // utile de faire ça ici ? --> ballPos = transform.position;
        if(collision.gameObject.CompareTag("Player"))
        {
            // rebond sur le player avec calcul d'angle selon la pos du player avec deltapos
            playerPos = collision.gameObject.transform.position;
            ballPos = transform.position;
            float deltaPos = ballPos.x - playerPos.x;
            rig.linearVelocity = new Vector2(deltaPos * ballSpeed, directionY * ballSpeed).normalized * ballSpeed;
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            //TODO: rebonds sur les murs
        }
        if(collision.gameObject.CompareTag("Brick"))
        {
            //TODO: rebonds sur les briques et destruction

            Destroy(collision.gameObject);
        }
    }
}
