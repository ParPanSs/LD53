using System.Linq;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private SlotsManager slotsManager;
    [SerializeField] private Transform[] _slots;
    void Update()
    {
        var fullSlot = _slots.Where(slot => slot.childCount == 1).ToList();
        foreach (var sprite in fullSlot)
        {
            sprite.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
            
        var emptySlot = _slots.Where(slot => slot.childCount == 0).ToList();
        foreach (var sprite in emptySlot)
        {
            sprite.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        
        slotsManager.CheckFull();
    }
}