using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [Header("Path Settings")]
    public Transform[] waypoints;      // Points to move between
    public float speed = 3f;           // Movement speed
    public bool loop = true;           // Restart when reaching the end

    private int currentIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Move towards current waypoint
        Transform targetPoint = waypoints[currentIndex];
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );

        // If reached, move to next waypoint
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                if (loop)
                {
                    currentIndex = 0; // restart
                }
                else
                {
                    enabled = false; // stop moving
                }
            }
        }
    }
}

