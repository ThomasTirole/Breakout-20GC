using System.IO.Compression;
using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 10f;
    private int directionY = 1;
    private Vector2 playerPos;
    private Vector2 ballPos;
    private Rigidbody2D rig;
    private bool canBounce = true;
    private Vector2 currentDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ballPos = transform.position;
        currentDirection = new Vector2(0f, 1f); // vers le haut
        rig.linearVelocity = currentDirection * ballSpeed;
    }

    IEnumerator ResetBounce()
    {
        yield return new WaitForSeconds(0.01f);
        canBounce = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

            //TODO: ajouter les Tags sur les éléments du jeu
        ballPos = transform.position;
        if(collision.gameObject.CompareTag("Player"))
        {
            // rebond sur le player avec calcul d'angle selon la pos du player avec deltapos
            playerPos = collision.gameObject.transform.position;
            float deltaPos = ballPos.x - playerPos.x;
            currentDirection = new Vector2(deltaPos * ballSpeed, directionY * ballSpeed).normalized;
            rig.linearVelocity = currentDirection * ballSpeed;
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            //TODO: rebonds sur les murs
            //rig.linearVelocity = new Vector2(rig.linearVelocity.x * -1, rig.linearVelocity.y);
            currentDirection = new Vector2(currentDirection.x * -1, currentDirection.y);
            rig.linearVelocity = currentDirection * ballSpeed;
        }
        if(collision.gameObject.CompareTag("TopWall"))
        {
            //TODO: rebonds sur les briques et destruction
            currentDirection = new Vector2(currentDirection.x, currentDirection.y * -1);
            rig.linearVelocity = currentDirection * ballSpeed;
        }
        if(collision.gameObject.CompareTag("Brick") && canBounce)
        {
            canBounce = false;
            //TODO: rebonds sur les briques et destruction
            currentDirection = new Vector2(currentDirection.x, currentDirection.y * -1);
            rig.linearVelocity = currentDirection * ballSpeed;
            Destroy(collision.gameObject);
            StartCoroutine(ResetBounce());
        }
    }
}
