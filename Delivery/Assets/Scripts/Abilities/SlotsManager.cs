using System.Linq;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    [SerializeField] private Transform[] slots;
    [SerializeField] private GameObject[] movingPath;
    [SerializeField] private GameObject button;

    public void CheckFull()
    {
        var fullSlot = slots.Where(slot => slot.transform.childCount == 2).ToList();
        if (fullSlot.Count == slots.Length)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void SetPath()
    {
        if (slots[0].transform.GetChild(1).CompareTag("Hiding") &&
             slots[1].transform.GetChild(1).CompareTag("Hiding")
            
           )
        {
            movingPath[0].SetActive(true);
        }

        if (slots[0].transform.GetChild(1).CompareTag("Walk"))
        {
            movingPath[1].SetActive(true);
        }
        
        if (slots[0].transform.GetChild(1).CompareTag("Hiding") &&
            slots[1].transform.GetChild(1).CompareTag("Walk"))
        {
            movingPath[2].SetActive(true);
        }
    }

    public void SetPath2Loc()
    {
        if ((slots[0].transform.GetChild(1).CompareTag("Walk") &&
             slots[1].transform.GetChild(1).CompareTag("Walk") &&
             slots[2].transform.GetChild(1).CompareTag("Walk")) ||
           ( 
                slots[0].transform.GetChild(1).CompareTag("Walk") &&
                slots[1].transform.GetChild(1).CompareTag("Hiding") &&
                slots[2].transform.GetChild(1).CompareTag("Walk")))
        {
            movingPath[0].SetActive(true);
        }
        
        if ((slots[0].transform.GetChild(1).CompareTag("Walk") &&
             slots[1].transform.GetChild(1).CompareTag("Walk") &&
             slots[2].transform.GetChild(1).CompareTag("Hiding")) ||
            (
                slots[0].transform.GetChild(1).CompareTag("Walk") &&
                slots[1].transform.GetChild(1).CompareTag("Hiding") &&
                slots[2].transform.GetChild(1).CompareTag("Hiding"))
            )
        {
            movingPath[1].SetActive(true);
        }
        
        if(slots[0].transform.GetChild(1).CompareTag("Hiding"))
        {
            movingPath[2].SetActive(true);
        }
        
        
    }
}