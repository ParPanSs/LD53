using UnityEngine;

public class SlotsLoader : MonoBehaviour
{
    public SlotsSaver saver;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpawnPosition;

    private void Start()
    {
        foreach (var slot in saver.fullSlots)
        {
            slot.gameObject.SetActive(true);
        }
    }
}
