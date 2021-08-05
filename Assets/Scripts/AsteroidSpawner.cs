using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;
    // Start is called before the first frame update
    void Start()
    {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        float colliderRadius = prefabAsteroid.GetComponent<CircleCollider2D>().radius;
        Destroy(asteroid);

        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroids script = asteroid.GetComponent<Asteroids>();
        script.Initialize(Direction.Left,new Vector2(ScreenUtils.ScreenRight + colliderRadius,
            ScreenUtils.ScreenBottom+screenHeight/2));

        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroids>();
        script.Initialize(Direction.Right, new Vector2(ScreenUtils.ScreenLeft - colliderRadius,
            ScreenUtils.ScreenBottom + screenHeight / 2));

        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroids>();
        script.Initialize(Direction.Up, new Vector2(ScreenUtils.ScreenBottom - colliderRadius,
            ScreenUtils.ScreenLeft + screenWidth / 2));

        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroids>();
        script.Initialize(Direction.Down, new Vector2(ScreenUtils.ScreenTop + colliderRadius,
            ScreenUtils.ScreenLeft + screenWidth / 2));
        
    }

    
}
