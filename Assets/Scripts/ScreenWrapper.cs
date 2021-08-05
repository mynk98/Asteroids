using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float colliderRadius; 
    // Start is called before the first frame update
    void Start()
    {
        colliderRadius = GetComponent<CircleCollider2D>().radius;
        
    }

    // Update is called once per frame
    void OnBecameInvisible()
    {
        Vector3 position = transform.position;
        if (position.x + colliderRadius >= ScreenUtils.ScreenRight ||
            position.x - colliderRadius <= ScreenUtils.ScreenLeft)
        {
            position.x *= -1;
            transform.position = position;
        }
        if (position.y + colliderRadius >= ScreenUtils.ScreenTop ||
            position.y - colliderRadius <= ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
            transform.position = position;
        }
    }
}
