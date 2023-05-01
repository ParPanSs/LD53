using UnityEngine;

[RequireComponent(typeof(DetactableObject))]
public class DetectableObjectReaction : MonoBehaviour
{
    private IDetectableObject _detectableObject;

    [SerializeField] private Player player;
    
    private void Awake()
    {
        _detectableObject = GetComponent<IDetectableObject>();
    }

    private void OnEnable()
    {
        if (player != null)
        {
            _detectableObject.OnGameObjectDetectedEvent += OnGameObjectDetect;
            _detectableObject.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
        }
        else
        {
            OnEnable();
        }
    }

    private void OnDisable()
    {
        _detectableObject.OnGameObjectDetectedEvent -= OnGameObjectDetect;
        _detectableObject.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }


    private void SetPlayerBehaviour()
    {
        if (_detectableObject.gameObject.CompareTag("Walk"))
        {
            player.SetBehaviourWalk();
        }
        if (_detectableObject.gameObject.CompareTag("Hiding"))
        {
            player.SetBehaviourHiding();
        }
        if (_detectableObject.gameObject.CompareTag("IDLE"))
        {
            player.SetBehaviourIdle();
        }
    }
    
    private void OnGameObjectDetect(GameObject source, GameObject detectedObject)
    {
        Debug.Log("Detected smth");
        SetPlayerBehaviour();
    }
    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        
    }
}
