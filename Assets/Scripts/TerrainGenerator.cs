using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // The point to generate the terrain
    public GameObject point;
    // A list to store all points
    public List<Vector3> terrain;
    // The left bound
    private int leftX = -10;
    // The right bound
    private int rightX = 10;
    // The lower bound
    public int ground = -5;
    // To remember the index of current point
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the whole terrain initially
        terrain = new List<Vector3>();
        Generate();
    }

    void Generate()
    {
        // Need to remember the previous point, in order to draw a line between two points
        GameObject previousPoint = null;
        Vector3 previousPoint_position = new Vector3();
        // Initialize an offset
        float add = 0;
        // Generally a piecewise function here, to ensure we only have one mound here
        for (float i = leftX; i < rightX; i += 0.025f)
        {
            if (i < -4 || i > 4)
            {
                add = 0;
            }
            else if (i < -3 && i >= -4)
            {
                add += 0.0125f;
            }
            else if (i < -2 && i >= -3)
            {
                add += 0.025f;
            }
            else if (i < -1 && i >= -2)
            {
                add += 0.0375f;
            }
            else if (i < 0 && i >= -1)
            {
                add += 0.05f;
            }
            else if (i < 1 && i >= 0)
            {
                add -= 0.0125f;
            }
            else if (i < 2 && i >= 1)
            {
                add -= 0.025f;
            }
            else if (i < 3 && i >= 2)
            {
                add -= 0.0375f;
            }
            else if (i < 4 && i >= 3)
            {
                add -= 0.05f;
            }
            // Using the perlin function here to generate a texture noise here
            System.Random random = new System.Random();
            float rnd = random.Next(1000);
            float offset = Perlin(i + rnd);
            GameObject block = point;
            Vector3 block_position;
            // The noise should be small on the ground
            if (i < -4 || i > 4)
            {
                block_position = new Vector3(i, ground + offset / 5, 0);
            }
            // The noise should be slightly larger on the mountain
            else
            {
                block_position = new Vector3(i, ground + add + offset, 0);
            }
            // Insert the point to the list
            terrain.Insert(index, block_position);
            index++;
            // Draw a point here
            Instantiate(block, block_position, Quaternion.identity);
            // Initialize the previous point if it is null
            if (previousPoint == null)
            {
                previousPoint = block;
                previousPoint_position = block_position;
            }
            // Draw the line between two points
            else
            {
                GameObject line1 = Instantiate(Resources.Load("Line", typeof(GameObject))) as GameObject;
                LineRenderer lineRenderer = line1.GetComponent<LineRenderer>();
                lineRenderer.SetPosition(0, previousPoint_position);
                lineRenderer.SetPosition(1, block_position);
                previousPoint = block;
                previousPoint_position = block_position;
            }
        }
    }
    // several helper functions to implement Perlin Noise
    float Noise(float x)
    {
        // Use Sine and Cosine to ensure the value not large
        float x1 = (Mathf.Cos(x) + Mathf.Sin(x)) / 2;
        float x2 = (Mathf.Cos(x - 1) + Mathf.Sin(x - 1)) / 4;
        float x3 = (Mathf.Cos(x + 1) + Mathf.Sin(x + 1)) / 4;
        return x1 + x2 + x3;
    }
    // Interpolate the value so that the curve will be smoother
    float Interpolate(float x)
    {
        int intX = (int)x;
        float diff = x - intX;
        float v1 = Noise(intX);
        float v2 = Noise(intX + 1);
        float w = (1 - Mathf.Cos(diff * 3.14159f)) * 0.5f;
        return v1 * (1 - w) + v2 * w;
    }
    // As we did in class, as the iteration increases, the amplitude will be lower
    float Perlin(float x)
    {
        float sum = 0;
        for (int i = 0; i < 9; i++)
        {
            int frequency = 2 ^ i;
            float amplitude = 4 ^ i;
            sum += Interpolate(x * frequency) * amplitude;
        }
        return sum / 100;
    }
}