using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Asteroids : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    float force;
    //[SerializeField]
    GameObject hud1;
    HUD1 script;
    string currentScene;
    KeepSpawning spawnScript;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "HighScore")
        {
            hud1 = GameObject.FindGameObjectWithTag("HUD1");
            script = hud1.GetComponent<HUD1>();
            spawnScript = Camera.main.GetComponent<KeepSpawning>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Direction direction, Vector3 location)
    {
        const float maxForce = 4;
        const float minForce = 2;
        force = Random.Range(minForce, maxForce);
        float angle = Random.Range(0, Mathf.PI/6);
        
        if (direction == Direction.Up)
        {
            angle += (75 * (Mathf.PI / 180));

        }
        else if (direction == Direction.Left)
        {
            angle += (165 * (Mathf.PI / 180));

        }
        else if (direction == Direction.Down)
        {
            angle += (255 * (Mathf.PI / 180));

        }
        else if (direction == Direction.Right)
        {
            angle += (345 * (Mathf.PI / 180));

        }
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Transform>().position = location;
        GetComponent<Rigidbody2D>().AddForce(moveDirection * force,ForceMode2D.Impulse);

        int spriteNumber = Random.Range(0, 3);
        Sprite astroSprite = sprites[spriteNumber];
        GetComponent<SpriteRenderer>().sprite = astroSprite;
        //print("d");
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            AudioManager.Play(AudioClipName.AsteroidHit);
            


            if (gameObject.transform.localScale.x == 0.5f)
            {
                Destroy(gameObject);
                if (currentScene == "HighScore")
                {
                    spawnScript.UpdateCount();
                    script.UpdateScore(10);

                }


            }
            else
            {
                Vector3 localScale = GetComponent<Transform>().localScale;
                localScale.x /= 2;
                localScale.y /= 2;
                gameObject.transform.localScale = localScale;
                //CircleCollider2D asteroidCollider = GetComponent<CircleCollider2D>();
                //float radius=asteroidCollider.radius/2;
                //asteroidCollider.radius = radius;

                GameObject newAsteroid1 = Instantiate(gameObject);
                newAsteroid1.GetComponent<Asteroids>().StartMoving(Random.Range(0, Mathf.PI));
                //float angle = Random.Range(0, Mathf.PI);
                //newAsteroid1.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * force,
                //    ForceMode2D.Impulse);

                GameObject newAsteroid2 = Instantiate(gameObject);
                newAsteroid2.GetComponent<Asteroids>().StartMoving(Random.Range(0, Mathf.PI));
                //angle = Random.Range(0, Mathf.PI);
                //newAsteroid2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * force,
                //    ForceMode2D.Impulse);

                Destroy(gameObject);
                if (currentScene == "HighScore")
                {
                    script.UpdateScore(5);
                }
            }
        }
    }
    public void StartMoving(float angle)
    {
        const float maxForce = 4;
        const float minForce = 2;
        force = Random.Range(minForce, maxForce);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * force,
            ForceMode2D.Impulse);
    }
        
}
