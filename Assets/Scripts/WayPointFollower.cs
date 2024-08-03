using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

   public List<Transform> waypoints = new List<Transform>();
    private int currentIndex = 0;
    [SerializeField] private float speed = 5;

    private void Awake()
    {
        LoadWaypoints();
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, waypoints[currentIndex].position) < 0.1f)
        {
            currentIndex++;
            currentIndex = currentIndex >= waypoints.Count ? 0 : currentIndex;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].position, Time.deltaTime * speed);
    }

    void LoadWaypoints()
    {
        waypoints.Clear();
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            var child = transform.parent.GetChild(i);
            if (child.name.Contains("WayPoint"))
            {
                waypoints.Add(child);
            }
        };
    }
}
