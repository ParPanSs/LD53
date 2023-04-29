using UnityEngine;

public class InputTest : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            player.SetBehaviourAgressive();
        if(Input.GetKeyDown(KeyCode.C))
            player.SetBehaviourActive();
        if(Input.GetKeyDown(KeyCode.I))
            player.SetBehaviourIdle();
    }
}
