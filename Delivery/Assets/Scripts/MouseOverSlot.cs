using UnityEngine;

public class MouseOverSlot : MonoBehaviour
{
    private void OnMouseOver()
    {   
        if(gameObject.transform.childCount == 1)
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        if(gameObject.transform.childCount > 0)
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
