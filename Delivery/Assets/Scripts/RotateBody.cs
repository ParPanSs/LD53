using UnityEngine;

public class RotateBody : MonoBehaviour
{
    public LayerMask groundLayer;
    private float raycastDistance = 1.5f;
    private Vector2 _normal;

    void Update()
    {
        Debug.DrawRay(transform.position,Vector2.down,Color.red,raycastDistance);
        Debug.DrawRay(transform.position,Vector2.up,Color.red,raycastDistance);
        Debug.DrawRay(transform.position,Vector2.left,Color.red,raycastDistance);
        Debug.DrawRay(transform.position,Vector2.right,Color.red,raycastDistance);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);
        if (hit.collider != null)
        {
            _normal = hit.normal;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _normal);
        } 
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.up, raycastDistance, groundLayer);
        if (hit2.collider != null)
        {
            _normal = hit2.normal;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _normal);
        }
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, groundLayer);
        if (hit3.collider != null)
        {
            _normal = hit3.normal;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _normal);
        }  
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, groundLayer);
        if (hit4.collider != null)
        {
            _normal = hit4.normal;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _normal);
        }
    }
}