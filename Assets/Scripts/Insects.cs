using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insects : MonoBehaviour
{
    // Velocity and horizontal acceleration
    private float ax, ay;
    // private float vx, vy;
    // The initial position of an insect
    public Vector3 initial = new Vector3(0, 0, 0);
    // The current shape of insects
    public List<Vector3> current = new List<Vector3>();
    // The initial shape of insects, so it is able to return to the initial shape
    public List<Vector3> originalShape = new List<Vector3>();
    // To store the points of insects from the previous state
    public List<Vector3> previous;
    // 16 lines needed to draw the insects
    LineRenderer lineRenderer1;
    LineRenderer lineRenderer2;
    LineRenderer lineRenderer3;
    LineRenderer lineRenderer4;
    LineRenderer lineRenderer5;
    LineRenderer lineRenderer6;
    LineRenderer lineRenderer7;
    LineRenderer lineRenderer8;
    LineRenderer lineRenderer9;
    LineRenderer lineRenderer10;
    LineRenderer lineRenderer11;
    LineRenderer lineRenderer12;
    LineRenderer lineRenderer13;
    LineRenderer lineRenderer14;
    LineRenderer lineRenderer15;
    LineRenderer lineRenderer16;

    void Start()
    {
        // Load 16 lines to draw the insect
        GameObject line1 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer1 = line1.GetComponent<LineRenderer>();
        GameObject line2 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer2 = line2.GetComponent<LineRenderer>();
        GameObject line3 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer3 = line3.GetComponent<LineRenderer>();
        GameObject line4 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer4 = line4.GetComponent<LineRenderer>();
        GameObject line5 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer5 = line5.GetComponent<LineRenderer>();
        GameObject line6 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer6 = line6.GetComponent<LineRenderer>();
        GameObject line7 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer7 = line7.GetComponent<LineRenderer>();
        GameObject line8 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer8 = line8.GetComponent<LineRenderer>();
        GameObject line9 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer9 = line9.GetComponent<LineRenderer>();
        GameObject line10 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer10 = line10.GetComponent<LineRenderer>();
        GameObject line11 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer11 = line11.GetComponent<LineRenderer>();
        GameObject line12 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer12 = line12.GetComponent<LineRenderer>();
        GameObject line13 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer13 = line13.GetComponent<LineRenderer>();
        GameObject line14 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer14 = line14.GetComponent<LineRenderer>();
        GameObject line15 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer15 = line15.GetComponent<LineRenderer>();
        GameObject line16 = Instantiate(Resources.Load("LineTwo", typeof(GameObject))) as GameObject;
        lineRenderer16 = line16.GetComponent<LineRenderer>();
        // The initial position
        initial = gameObject.transform.position;
        // Initialize the insect
        CreateInsect();
        // Initialize the acceleration
        ax = 0f;
        ay = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Do the collision detection
        CollisionDetection();
        // Move with constraints
        Move();
        // Draw the insects
        Draw();
    }

    void CreateInsect()
    {
        // Initialize the insect with some offset, so they will not be drawn at the same position
        Vector3 offset = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
        current.Add(new Vector3(-5.19f, 0.2f, 0) + offset);
        current.Add(new Vector3(-4.72f, 0.2f, 0) + offset);
        current.Add(new Vector3(-4.96f, -0.4f, 0) + offset);
        current.Add(new Vector3(-5.61f, -0.08f, 0) + offset);
        current.Add(new Vector3(-5.6f, -0.36f, 0) + offset);
        current.Add(new Vector3(-5.61f, -0.65f, 0) + offset);
        current.Add(new Vector3(-5.61f, -0.89f, 0) + offset);
        current.Add(new Vector3(-4.32f, -0.07f, 0) + offset);
        current.Add(new Vector3(-4.32f, -0.34f, 0) + offset);
        current.Add(new Vector3(-4.32f, -0.63f, 0) + offset);
        current.Add(new Vector3(-4.32f, -0.91f, 0) + offset);
        // Store the initial positions of points as the original shape, we need to be able to restore the original shape
        // And need the previous shape as we implement the movement by Verlet integration
        for (int i = 0; i < current.Count; i++)
        {
            originalShape.Add(new Vector3(current[i].x, current[i].y, 0));
            previous.Add(new Vector3(current[i].x, current[i].y, 0));
        }
    }

    void Draw()
    {
        // antennae 1
        lineRenderer1.SetPosition(0, current[0]);
        lineRenderer1.SetPosition(1, current[2]);
        // antennae2
        lineRenderer2.SetPosition(0, current[1]);
        lineRenderer2.SetPosition(1, current[2]);
        // Left to body
        lineRenderer3.SetPosition(0, current[3]);
        lineRenderer3.SetPosition(1, current[2]);
        lineRenderer4.SetPosition(0, current[4]);
        lineRenderer4.SetPosition(1, current[2]);
        lineRenderer5.SetPosition(0, current[5]);
        lineRenderer5.SetPosition(1, current[2]);
        lineRenderer6.SetPosition(0, current[6]);
        lineRenderer6.SetPosition(1, current[2]);
        // Right to body
        lineRenderer7.SetPosition(0, current[7]);
        lineRenderer7.SetPosition(1, current[2]);
        lineRenderer8.SetPosition(0, current[8]);
        lineRenderer8.SetPosition(1, current[2]);
        lineRenderer9.SetPosition(0, current[9]);
        lineRenderer9.SetPosition(1, current[2]);
        lineRenderer10.SetPosition(0, current[10]);
        lineRenderer10.SetPosition(1, current[2]);
        // Left
        lineRenderer11.SetPosition(0, current[3]);
        lineRenderer11.SetPosition(1, current[4]);
        lineRenderer12.SetPosition(0, current[4]);
        lineRenderer12.SetPosition(1, current[5]);
        lineRenderer13.SetPosition(0, current[5]);
        lineRenderer13.SetPosition(1, current[6]);
        // Right
        lineRenderer14.SetPosition(0, current[7]);
        lineRenderer14.SetPosition(1, current[8]);
        lineRenderer15.SetPosition(0, current[8]);
        lineRenderer15.SetPosition(1, current[9]);
        lineRenderer16.SetPosition(0, current[9]);
        lineRenderer16.SetPosition(1, current[10]);
    }

    void Move()
    {
        System.Random rnd = new System.Random();
        for (int i = 0; i < current.Count; i++)
        {
            ax = Random.Range(-0.0005f, 0.0005f);
            ay = Random.Range(-0.0003f, 0.0003f);
            // Implement the verlet integration to each vertice of the insect, new position = 2 * current postion - previous position + acceleration
            Vector3 newPoint = 2 * current[i] - previous[i] + new Vector3(ax, ay, 0);
            previous[i] = current[i];
            current[i] = newPoint;
        }
        // In addtion to the simple verlet integration, we need more constraints to ensure the shape of the insect
        // This part is elaborated in the pdf
        // Set the tolerance between antenna and body
        float oad = GetDistance(originalShape[0], originalShape[2]);
        float aMax = 1.1f * oad;
        float aMin = 0.9f * oad;
        float ad1 = GetDistance(current[0], current[2]);
        float ad2 = GetDistance(current[1], current[2]);
        // If the distance is smaller or greater than the tolerance, restore the initial shape of such part
        if (ad1 > aMax || ad1 < aMin)
        {
            current[0] = current[2] + new Vector3(originalShape[0].x - originalShape[2].x, originalShape[0].y - originalShape[2].y, 0);
        }
        if (ad2 > aMax || ad2 < aMin)
        {
            current[1] = current[2] + new Vector3(originalShape[1].x - originalShape[2].x, originalShape[1].y - originalShape[2].y, 0);
        }
        // Set the tolerance between wing point and body
        float owb = GetDistance(originalShape[3], originalShape[2]);
        float wbMax = 1.2f * owb;
        float wbMin = 0.8f * owb;
        float wb1 = GetDistance(current[3], current[2]);
        float wb2 = GetDistance(current[4], current[2]);
        float wb3 = GetDistance(current[5], current[2]);
        float wb4 = GetDistance(current[6], current[2]);
        float wb5 = GetDistance(current[7], current[2]);
        float wb6 = GetDistance(current[8], current[2]);
        float wb7 = GetDistance(current[9], current[2]);
        float wb8 = GetDistance(current[10], current[2]);
        // If the distance is smaller or greater than the tolerance, restore the initial shape of such part
        if (wb1 > wbMax || wb1 < wbMin)
        {
            current[3] = current[2] + new Vector3(originalShape[3].x - originalShape[2].x, originalShape[3].y - originalShape[2].y, 0);
        }
        if (wb2 > wbMax || wb2 < wbMin)
        {
            current[4] = current[2] + new Vector3(originalShape[4].x - originalShape[2].x, originalShape[4].y - originalShape[2].y, 0);
        }
        if (wb3 > wbMax || wb4 < wbMin)
        {
            current[5] = current[2] + new Vector3(originalShape[5].x - originalShape[2].x, originalShape[5].y - originalShape[2].y, 0);
        }
        if (wb4 > wbMax || wb4 < wbMin)
        {
            current[6] = current[2] + new Vector3(originalShape[6].x - originalShape[2].x, originalShape[6].y - originalShape[2].y, 0);
        }
        if (wb5 > wbMax || wb5 < wbMin)
        {
            current[7] = current[2] + new Vector3(originalShape[7].x - originalShape[2].x, originalShape[7].y - originalShape[2].y, 0);
        }
        if (wb6 > wbMax || wb6 < wbMin)
        {
            current[8] = current[2] + new Vector3(originalShape[8].x - originalShape[2].x, originalShape[8].y - originalShape[2].y, 0);
        }
        if (wb7 > wbMax || wb7 < wbMin)
        {
            current[9] = current[2] + new Vector3(originalShape[9].x - originalShape[2].x, originalShape[9].y - originalShape[2].y, 0);
        }
        if (wb8 > wbMax || wb8 < wbMin)
        {
            current[10] = current[2] + new Vector3(originalShape[10].x - originalShape[2].x, originalShape[10].y - originalShape[2].y, 0);
        }
        // Set the tolerance between wing point and wing point
        float oww = GetDistance(originalShape[3], originalShape[4]);
        float wwMax = 1.1f * oww;
        float wwMin = 0.9f * oww;
        float ww1 = GetDistance(originalShape[3], originalShape[4]);
        float ww2 = GetDistance(originalShape[4], originalShape[5]);
        float ww3 = GetDistance(originalShape[5], originalShape[6]);
        float ww4 = GetDistance(originalShape[7], originalShape[8]);
        float ww5 = GetDistance(originalShape[8], originalShape[9]);
        float ww6 = GetDistance(originalShape[9], originalShape[10]);
        // If the distance is smaller or greater than the tolerance, restore the initial shape of such part
        if (ww1 > wwMax || ww1 < wwMin)
        {
            current[3] = current[2] + new Vector3(originalShape[3].x - originalShape[2].x, originalShape[3].y - originalShape[2].y, 0);
            current[4] = current[2] + new Vector3(originalShape[4].x - originalShape[2].x, originalShape[4].y - originalShape[2].y, 0);
        }
        if (ww2 > wwMax || ww2 < wwMin)
        {
            current[4] = current[2] + new Vector3(originalShape[4].x - originalShape[2].x, originalShape[4].y - originalShape[2].y, 0);
            current[5] = current[2] + new Vector3(originalShape[5].x - originalShape[2].x, originalShape[5].y - originalShape[2].y, 0);
        }
        if (ww3 > wwMax || ww3 < wwMin)
        {
            current[5] = current[2] + new Vector3(originalShape[5].x - originalShape[2].x, originalShape[5].y - originalShape[2].y, 0);
            current[6] = current[2] + new Vector3(originalShape[6].x - originalShape[2].x, originalShape[6].y - originalShape[2].y, 0);
        }
        if (ww4 > wwMax || ww4 < wwMin)
        {
            current[7] = current[2] + new Vector3(originalShape[7].x - originalShape[2].x, originalShape[7].y - originalShape[2].y, 0);
            current[8] = current[2] + new Vector3(originalShape[8].x - originalShape[2].x, originalShape[8].y - originalShape[2].y, 0);
        }
        if (ww5 > wwMax || ww5 < wwMin)
        {
            current[8] = current[2] + new Vector3(originalShape[8].x - originalShape[2].x, originalShape[8].y - originalShape[2].y, 0);
            current[9] = current[2] + new Vector3(originalShape[9].x - originalShape[2].x, originalShape[9].y - originalShape[2].y, 0);
        }
        if (ww6 > wwMax || ww6 < wwMin)
        {
            current[9] = current[2] + new Vector3(originalShape[9].x - originalShape[2].x, originalShape[9].y - originalShape[2].y, 0);
            current[10] = current[2] + new Vector3(originalShape[10].x - originalShape[2].x, originalShape[10].y - originalShape[2].y, 0);
        }
    }

    // A helper function to calculate the distance between two point
    private float GetDistance(Vector3 p1, Vector3 p2)
    {
        float sum = Mathf.Pow(p1.x - p2.x, 2) + Mathf.Pow(p1.y - p2.y, 2);
        float distance = Mathf.Sqrt(sum);
        return distance;
    }

    // The collision detection of the insect
    void CollisionDetection()
    {
        // Check if the insect collides with the airwall from the left
        // If any point touch the air wall, it should be a collision
        foreach (Vector3 pts in current)
        {
            if (pts.x >= 6)
            {
                // Need to destory those lines as well
                Destroy(lineRenderer1);
                Destroy(lineRenderer2);
                Destroy(lineRenderer3);
                Destroy(lineRenderer4);
                Destroy(lineRenderer5);
                Destroy(lineRenderer6);
                Destroy(lineRenderer7);
                Destroy(lineRenderer8);
                Destroy(lineRenderer9);
                Destroy(lineRenderer10);
                Destroy(lineRenderer11);
                Destroy(lineRenderer12);
                Destroy(lineRenderer13);
                Destroy(lineRenderer14);
                Destroy(lineRenderer15);
                Destroy(lineRenderer16);
                Destroy(gameObject);
                InsectsManager.numberOfInsects--;
                break;
            }
        }
        // Check if the insect go out of screen from the upper bound
        if (current[2].y > 5.3)
        {
            // Need to destory those lines as well
            Destroy(lineRenderer1);
            Destroy(lineRenderer2);
            Destroy(lineRenderer3);
            Destroy(lineRenderer4);
            Destroy(lineRenderer5);
            Destroy(lineRenderer6);
            Destroy(lineRenderer7);
            Destroy(lineRenderer8);
            Destroy(lineRenderer9);
            Destroy(lineRenderer10);
            Destroy(lineRenderer11);
            Destroy(lineRenderer12);
            Destroy(lineRenderer13);
            Destroy(lineRenderer14);
            Destroy(lineRenderer15);
            Destroy(lineRenderer16);
            Destroy(gameObject);
            InsectsManager.numberOfInsects--;
        }
        // Check if the insect touches the vertical wall on the left
        for (int i = 0; i < 11; i++)
        {
            if (current[i].x <= -8.11f)
            {
                // Just simply reset the postion of the insect to the postion of the vertical wall
                current[i] = new Vector3(-8.1f, current[i].y, 0);
            }
        }
        // Check if the insect touches the terrain
        TerrainGenerator terrain = GameObject.FindObjectOfType<TerrainGenerator>();
        float t = terrain.point.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        // Debug.Log(t.ToString());
        for (int i = 0; i < 11; i++)
        {
            foreach (Vector3 pts in terrain.terrain)
            {
                if (GetDistance(current[i], pts) <= t)
                {
                    // current[i] = new Vector3(pts.x, pts.y + 0.1f, 0);
                    for (int j = 0; j < 11; j++)
                    {
                        // Similar to the collision detection of the vertical wall
                        current[j] = current[j] + new Vector3(0, 0.01f, 0);
                    }
                }
            }
        }
        // Check if there's a bullet approaching the insect
        // The bullet is unable to touch the insect in most cases
        // since the insect should notice that there's a bullet approaching and try to elude it
        float radius;
        System.Random rnd = new System.Random();
        bool up;
        bool left;
        for (int i = 0; i < 11; i++)
        {
            foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
            {
                Vector3 pts = current[i];
                radius = bullet.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                // estimate the direction to elude the bullet
                /*
                    if the insect is lower than the bullet, then move lower to elude
                    if the insect is higher than the bullet, then move higher to elude
                    if the bullet is moving to the left, then move to the left to elude
                    if the bullet is moving to the right, then move to the right to elude
                */
                if (pts.y < bullet.transform.position.y)
                {
                    up = false;
                }
                else
                {
                    up = true;
                }
                if (bullet.GetComponent<Bullet>().vx < 0)
                {
                    left = false;
                }
                else
                {
                    left = true;
                }
                // Add 0.5f offset here, since the insect will elude in advance, rather than at the moment when touching the bullet
                if (GetDistance(pts, bullet.transform.position) <= radius + 0.5f)
                {
                    // Handle different cases
                    if (up && left)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            current[j] = current[j] + new Vector3(-0.01f, 0.01f, 0);
                        }
                    }
                    else if (up && !left)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            current[j] = current[j] + new Vector3(0.01f, 0.01f, 0);
                        }
                    }
                    else if (!up && left)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            current[j] = current[j] + new Vector3(-0.01f, -0.01f, 0);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            current[j] = current[j] + new Vector3(0.01f, -0.01f, 0);
                        }
                    }
                }
            }
        }
        // Check if the insect enters the wind region
        WindManager windManager = GameObject.FindObjectOfType<WindManager>();
        // Wind Region1
        if (current[2].x <= -6.93f && current[2].x >= -7.56f)
        {
            for (int j = 0; j < 11; j++)
            {
                current[j] = current[j] + new Vector3(0, windManager.wind1Speed, 0);
            }
        }
        // Wind Region2
        if (current[2].x <= -5.13f && current[2].x >= -5.77f)
        {
            for (int j = 0; j < 11; j++)
            {
                current[j] = current[j] + new Vector3(0, windManager.wind2Speed, 0);
            }
        }
        // Wind Region3
        if (current[2].x <= -3.217f && current[2].x >= -3.849f)
        {
            for (int j = 0; j < 11; j++)
            {
                current[j] = current[j] + new Vector3(0, windManager.wind3Speed, 0);
            }
        }
    }
}
