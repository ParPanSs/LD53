using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private Transform startParent;

    private void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y + 2f);
        startParent = transform.parent;
    }
    private void OnMouseDown()
    {
        if (!isDragging)
        {
            isDragging = true;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        bool isOverSlot = false;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Slot"))
            {
                if (collider.gameObject.transform.childCount == 1)
                {
                    transform.position = startPosition;
                }
                else
                {
                    collider.transform.GetComponent<SpriteRenderer>().enabled = false;
                    transform.position = collider.transform.position;
                    transform.SetParent(collider.transform);
                    isOverSlot = true;
                    break;
                }
            }
        }

        if (!isOverSlot)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}