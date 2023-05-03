using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private Player player;
    private enum MovementType
    {
        Moving,
        Lerping
    }
    
    [SerializeField] private MovementType type = MovementType.Moving;
    private MovingPath myPath;
    private float maxDistance = .1f;

    private void Start()
    {
        myPath = FindObjectOfType<MovingPath>();
        if (myPath == null)
        {
            return;
        }

        pointInPath = myPath.GetNextPathPoint();
        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    private void Update()
    {
        
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        if (type == MovementType.Moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                pointInPath.Current.position,
                Time.deltaTime * Player.Speed);
        }
        else if (type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position,
                Time.deltaTime * Player.Speed);
        }

        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;

        if (distanceSquare < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }
    }

    private IEnumerator<Transform> pointInPath;
}
