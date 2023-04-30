using System.Linq;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    public SlotsSaver saver;
    [SerializeField] private Transform[] slots;
    [SerializeField] private GameObject button;

    public bool CheckFull()
    {
        var fullSlot = slots.Where(slot => slot.transform.childCount == 1).ToList();
        if (fullSlot.Count == slots.Length)
        {
            button.SetActive(true);
            return true;
        }
        else
        {
            button.SetActive(false);
        }

        return false;
    }

    public void SaveSlots()
    {  
        var fullSlot = slots.Where(slot => slot.transform.childCount == 1).ToList();
        foreach (Transform slot in fullSlot)
        {
            var ability = slot.GetComponentInChildren<Transform>();
            saver.fullSlots.Add(ability);
        }
    }
}