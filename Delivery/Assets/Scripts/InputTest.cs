using UnityEngine;

public class InputTest : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            player.SetBehaviourWalk();
        if(Input.GetKeyDown(KeyCode.C))
            player.SetBehaviourIdle();
        if(Input.GetKeyDown(KeyCode.I))
            player.SetBehaviourHiding();
    }
}
