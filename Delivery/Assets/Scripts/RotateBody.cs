using UnityEngine;

public class RotateBody : MonoBehaviour
{
    public LayerMask groundLayer;
    public float raycastDistance = Mathf.Infinity;
    private Vector2 _normal;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);

        if (hit.collider != null)
        {
            _normal = hit.normal;
            float angle = Vector2.Angle(_normal, transform.position);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _normal);
        }
    }
}