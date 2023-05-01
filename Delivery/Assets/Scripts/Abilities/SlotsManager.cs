using System.Linq;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    [SerializeField] private Transform[] slots;
    [SerializeField] private GameObject button;

    public void CheckFull()
    {
        var fullSlot = slots.Where(slot => slot.transform.childCount == 1).ToList();
        if (fullSlot.Count == slots.Length)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
}