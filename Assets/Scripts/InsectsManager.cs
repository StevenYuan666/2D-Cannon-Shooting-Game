using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectsManager : MonoBehaviour
{
    // Get the object of insect
    public GameObject insect;
    // Need a static field to remember how many insects are showed
    public static int numberOfInsects;
    // Start is called before the first frame update
    void Start()
    {
        // Create three insects initially
        InsectsManager.numberOfInsects = 3;
        for (int i = 0; i < InsectsManager.numberOfInsects; i++)
        {
            Instantiate(insect, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the number of insects is smaller than 3 due to destruction, then create new one
        if (InsectsManager.numberOfInsects < 3)
        {
            for (int i = InsectsManager.numberOfInsects; i < 3; i++)
            {
                Instantiate(insect, transform.position, Quaternion.identity);
            }
            InsectsManager.numberOfInsects = 3;
        }
    }
}
