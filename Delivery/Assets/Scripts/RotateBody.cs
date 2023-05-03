using UnityEngine;

public class RotateBody : MonoBehaviour
{
    public LayerMask groundLayer;
    private float raycastDistance = 0.5f;
    private Vector2 _normal;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);
        if (hit.collider != null)
        {
            _normal = hit.normal;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _normal);
        }
    }
}