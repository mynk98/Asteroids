using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject hud;
    [SerializeField]
    GameObject prefabExplosion;
    Vector2 thrustDirection = new Vector2(1, 0);
    const int thrustForce = 5;
    float colliderRadius;
    const float rotateDegreesPerSecond = 150;
    int Switch = 0;
    [SerializeField]
    Joystick joystick;
    [SerializeField]
    FixedButton thrustButton;
    [SerializeField]
    FixedButton fireImage;
    bool isFire = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        colliderRadius = gameObject.GetComponent<CircleCollider2D>().radius;
        if (Application.isMobilePlatform )
        {
            joystick.gameObject.SetActive(true);
            thrustButton.gameObject.SetActive(true);
            fireImage.gameObject.SetActive(true);
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Rotate") != 0 || joystick.Horizontal!=0)
        {
            float rotationInput = -Input.GetAxis("Rotate");
            float joystickRotationInput = -joystick.Horizontal;
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime*rotationInput;
            float joystickRotationAmount = rotateDegreesPerSecond * Time.deltaTime*joystickRotationInput;
            transform.Rotate(Vector3.forward, rotationAmount);
            transform.Rotate(Vector3.forward, joystickRotationAmount);
            thrustDirection =new Vector2(Mathf.Cos(Mathf.PI*transform.eulerAngles.z/180), Mathf.Sin(Mathf.PI * transform.eulerAngles.z / 180));
        }

        
        if (!Application.isMobilePlatform)
        {
            if (Input.GetAxis("Fire1")!=0 && Switch == 0)
            {
                Switch = 1;
                GameObject bullet = Instantiate<GameObject>(bulletPrefab);
                bullet.transform.position = gameObject.transform.position;
                bullet.transform.rotation = gameObject.transform.rotation;
                Bullet script = bullet.GetComponent<Bullet>();
                script.ApplyForce(thrustDirection);

                AudioManager.Play(AudioClipName.PlayerShot);
            }
            if (Input.GetAxis("Fire1") == 0 )
            {
                Switch = 0;
            }
        }
        else
        {
            if (fireImage.Pressed)
            {
                isFire = true;
            }
            if (!fireImage.Pressed)
            {
                isFire = false;
            }
            if ((isFire) && Switch == 0)
            {
                Switch = 1;
                GameObject bullet = Instantiate<GameObject>(bulletPrefab);
                bullet.transform.position = gameObject.transform.position;
                bullet.transform.rotation = gameObject.transform.rotation;
                Bullet script = bullet.GetComponent<Bullet>();
                script.ApplyForce(thrustDirection);

                AudioManager.Play(AudioClipName.PlayerShot);
            }
            if (!isFire)
            {
                Switch = 0;
            }
        }
        
    }
    void FixedUpdate()
    {
        float thrustInput = Input.GetAxis("Thrust");
        if (thrustInput > 0 || thrustButton.Pressed)
        {
            rigidbody.AddForce(thrustDirection*thrustForce, ForceMode2D.Force);
            
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        HUD script=hud.GetComponent<HUD>();
        script.StopGameTimer();
        Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
        
    }

    
    
}
