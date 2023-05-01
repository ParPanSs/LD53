using UnityEngine;

public class AbilityList : MonoBehaviour
{
    private Animator _animator;
    private bool isMoving = false;
    private bool isOpen;
    private float duration = .5f; // длительность анимации в секундах
    private float timer = 0f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    [SerializeField] private GameObject[] abilities;

    private void OnMouseDown()
    {
        foreach (var ability in abilities)
        {
            ability.SetActive(true);
        }
        isOpen = !isOpen;
        if (isOpen)
        {
            isMoving = true;
            startPosition = transform.position;
            endPosition = startPosition + Vector3.up * 2.2f; // перемещаем объект вверх на 2 единицы
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
            _animator.SetBool("isOpen", false);
            Destroy(this);
        }
    }
}
