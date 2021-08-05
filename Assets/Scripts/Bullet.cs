using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Timer deathTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Timer>();
        deathTimer = GetComponent<Timer>();
        deathTimer.Duration = 1;
        deathTimer.Run();
        //timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
        /*(timer += Time.deltaTime;
        if (timer >= 2)
        {
            Destroy(gameObject);
        }*/
    }

    public void ApplyForce(Vector2 direction)
    {
        int magnitude = 10;
        Rigidbody2D rbd2d = gameObject.GetComponent<Rigidbody2D>();
        rbd2d.AddForce(magnitude * direction,ForceMode2D.Impulse);
    }
}
