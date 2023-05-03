using TMPro;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI text;
    private float _timer;
    [SerializeField] private float threeStars;
    [SerializeField] private float twoStars;

    [SerializeField] private GameObject[] stars;
    [SerializeField] private Animator integrity;
    private void Start()
    {
        Debug.Log(Player.currentHealth + " hp");
        integrity.enabled = true;
        text.gameObject.SetActive(true);
        _timer = player.timer;
        text.text = _timer + " Seconds!";
        if (_timer < threeStars && Player.currentHealth > 75)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else if (_timer <= twoStars && Player.currentHealth > 50)
        {
            stars[0].SetActive(true);
            stars[2].SetActive(true);
        }
        else
        {
            stars[0].SetActive(true);
        }
    }
}
