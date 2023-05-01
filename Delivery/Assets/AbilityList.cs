using UnityEngine;

public class AbilityList : MonoBehaviour
{
    private Animator _animator;
    private bool _isOpen;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("isOpen", _isOpen);
    }

    private void Update()
    {
        if (gameObject.transform.GetChild(0).childCount == 0 &&
            gameObject.transform.GetChild(1).childCount == 0 &&
            gameObject.transform.GetChild(2).childCount == 0)
        {
            _animator.SetBool("isOpen", false);
            Destroy(this);
        }
    }
}
