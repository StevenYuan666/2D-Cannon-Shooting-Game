using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public float muzzle;
    float shootTime;
    // Constrain the user to shoot less quickly
    private bool canShoot;
    // Control the angle of barrel only between 0 and 90 degrees
    public float angle;
    // Display the degree of connon and speed of bullet
    public Text degreeText, speedText;
    // Get the muzzle of barrel to shoot the bullet
    public GameObject muzzlePoint;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the speed of bullet
        muzzle = 80.0f;
        canShoot = true;
        angle = 0;
        // Display the numbers
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Power();
        Shoot();
        Show();
    }

    //Rotating Canon
    void Rotate()
    {
        if (Input.GetKey("up"))
        {
            // Cannot larger than 90 degrees
            if (angle < 90)
            {
                angle += 0.5f;
                transform.Rotate(0, 0, -0.5f);
            }
        }
        if (Input.GetKey("down"))
        {
            // Cannot smaller than 0 degrees
            if (angle > 0)
            {
                angle -= 0.5f;
                transform.Rotate(0, 0, 0.5f);
            }
        }
    }

    //Changing muzzle power
    void Power()
    {
        // Constrain the speed of bullet between 0 to 100
        if (Input.GetKeyDown("left") && muzzle > 1f)
        {
            muzzle -= 1f;
        }
        else if (Input.GetKeyDown("left") && muzzle <= 1f)
        {
            muzzle = 1f;
        }
        // Set an upper bound of the velocity
        if (Input.GetKeyDown("right") && muzzle < 100f)
        {
            muzzle += 1f;
        }
        else if (Input.GetKeyDown("right") && muzzle >= 100f)
        {
            muzzle = 100f;
        }
    }

    //Shooting
    void Shoot()
    {
        if (Input.GetKey("space") && canShoot)
        {
            // Only instantiate a bullet here, and control the movement of bullet in the script "Bullet"
            GameObject tempBullet = (GameObject)Instantiate(bullet, muzzlePoint.transform.position, Quaternion.identity);
            canShoot = false;
            shootTime = Time.time;
        }
        // Constrain the user shooting too quickly
        if (Time.time - shootTime > 0.5f && !canShoot)
        {
            canShoot = true;
        }
    }

    void Show()
    {
        degreeText.text = "Cannon Degree: " + angle.ToString();
        speedText.text = "Bullet Speed: " + muzzle.ToString();
    }


}
