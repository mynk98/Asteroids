using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSpawning : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;
    int count = 0;
    GameObject asteroid;
    float screenWidth;
    float screenHeight;
    float colliderRadius;
    int randomInt;
    Asteroids script;
    // Start is called before the first frame update
    void Start()
    {
        asteroid = Instantiate<GameObject>(prefabAsteroid);
        colliderRadius = prefabAsteroid.GetComponent<CircleCollider2D>().radius;
        Destroy(asteroid);

        screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 4)
        {
            count = 0;
            randomInt = Random.Range(1, 5);

            if (randomInt == 1)
            {
                asteroid = Instantiate<GameObject>(prefabAsteroid);
                script = asteroid.GetComponent<Asteroids>();
                script.Initialize(Direction.Left, new Vector2(ScreenUtils.ScreenRight + colliderRadius,
                    ScreenUtils.ScreenBottom + screenHeight / 2));
            }
            else if (randomInt == 2)
            {
                asteroid = Instantiate<GameObject>(prefabAsteroid);
                script = asteroid.GetComponent<Asteroids>();
                script.Initialize(Direction.Right, new Vector2(ScreenUtils.ScreenLeft - colliderRadius,
                    ScreenUtils.ScreenBottom + screenHeight / 2));
            }
            else if (randomInt == 3)
            {
                asteroid = Instantiate<GameObject>(prefabAsteroid);
                script = asteroid.GetComponent<Asteroids>();
                script.Initialize(Direction.Up, new Vector2(ScreenUtils.ScreenBottom - colliderRadius,
                    ScreenUtils.ScreenLeft + screenWidth / 2));
            }

            else
            {
                asteroid = Instantiate<GameObject>(prefabAsteroid);
                script = asteroid.GetComponent<Asteroids>();
                script.Initialize(Direction.Down, new Vector2(ScreenUtils.ScreenTop + colliderRadius,
                    ScreenUtils.ScreenLeft + screenWidth / 2));
            }
           

            

        }
        
    }

    public void UpdateCount()
    {
        count += 1;
    }

}
