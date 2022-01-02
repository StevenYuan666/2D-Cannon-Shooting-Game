using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindManager : MonoBehaviour
{
    // To show the value of speed of each wind region
    public Text wind1, wind2, wind3;
    // Three different wind speed
    public float wind1Speed, wind2Speed, wind3Speed;
    // Update the speed of wind every two seconds
    float timer = 2f;
    // Two numbers to control the random wind speed 
    // Need about half second to move an insect fromt the bottom to the top
    float coefficient = 200000f;
    int range = 100;
    // An random generator
    private System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        // Need to initialize the wind speed
        wind1Speed = rnd.Next(range) / coefficient;
        wind2Speed = rnd.Next(range) / coefficient;
        wind3Speed = rnd.Next(range) / coefficient;
        // Show the value
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the winds speed every two seconds
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            wind1Speed = rnd.Next(range) / coefficient;
            wind2Speed = rnd.Next(range) / coefficient;
            wind3Speed = rnd.Next(range) / coefficient;
            timer = 2f;
        }
        // Show the value
        Show();
    }

    void Show()
    {
        // Show the integer value, range from 0 to 100 to make more senses
        wind1.text = "Wind1 Speed: " + ((int)(wind1Speed * coefficient)).ToString();
        wind2.text = "Wind2 Speed: " + ((int)(wind2Speed * coefficient)).ToString();
        wind3.text = "Wind3 Speed: " + ((int)(wind3Speed * coefficient)).ToString();
    }
}
