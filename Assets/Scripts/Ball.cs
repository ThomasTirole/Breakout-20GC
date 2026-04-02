using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using System.Linq;

public class Ball : MonoBehaviour
{

    private AudioSource audioSource;

    public float ballSpeed = 10f;
    private int directionY = 1;
    private Vector2 initialPosition;
    private Vector2 playerPos;
    private Vector2 ballPos;
    private Rigidbody2D rig;
    private Vector2 currentDirection;

    public AudioClip bounceSound;
    public AudioClip brickSound;
    public AudioClip deathSound;

    
    public int balls = 3;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
        rig = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        InitLoad();
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
            audioSource.PlayOneShot(bounceSound);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(bounceSound);
        }
        if(collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            //remove brick from Gamemanager bricks list
            GameManager.instance.bricks = GameManager.instance.bricks.Where(b => b != collision.gameObject).ToArray();
            audioSource.PlayOneShot(brickSound);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            //TODO: ajouter une méthode pour gérer la mort du joueur et donc baisser le nombre de vie et réinitialiser la position de la balle
            balls--;
            UI.instance.UpdateHealth(balls);
            if (balls <= 0)
            {
                SceneManager.LoadScene(0); // reload the scene
                return;
            }
            audioSource.PlayOneShot(deathSound);
            transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f); // position de départ au dessus du player
            InitLoad();
        }
    }

    void InitLoad()
    {
        ballPos = transform.position;
        currentDirection = new Vector2(0f, 1f); // vers le haut
        rig.linearVelocity = currentDirection * ballSpeed;
    }

}
