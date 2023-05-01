using UnityEngine;

public class AbilityList : MonoBehaviour
{
    private Animator _animator;
    private bool isMoving = false;
    private bool isOpen;
    private float duration = .5f;
    private float timer = 0f;
    private Vector3 startPosition;
    private Vector3 abilityStartPosition;
    
    private Vector3 endPosition;
    private Vector3 abilityEndPosition;

    private void OnMouseDown()
    {
        
        isOpen = !isOpen;
        if (isOpen)
        {
            isMoving = true;
            startPosition = transform.position;
            endPosition = startPosition + Vector3.up * 2.2f; 
        }
        else
        {
            isMoving = true;
            startPosition = transform.position;
            endPosition = startPosition - Vector3.up * 2.2f;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            if (t >= 1f)
            {
                isMoving = false;
                timer = 0f;
            }
        }
        if (gameObject.transform.GetChild(0).childCount == 0 &&
            gameObject.transform.GetChild(1).childCount == 0 &&
            gameObject.transform.GetChild(2).childCount == 0)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            Destroy(this);
        }
    }
}