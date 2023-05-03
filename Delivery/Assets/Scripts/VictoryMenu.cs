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
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject bestTimer;
    [SerializeField] private GameObject bestHealth;
    [SerializeField] private float healthThreeStars;
    [SerializeField] private float healthTwoStars;

    private void Start()
    {
        _timer = player.timer;
        restartButton.SetActive(true);
        if (_timer > threeStars)
            bestTimer.SetActive(true);
        if (Player.currentHealth < healthThreeStars)
            bestHealth.SetActive(true);
        Debug.Log(Player.currentHealth + " hp");
        integrity.enabled = true;
        text.gameObject.SetActive(true);
        text.text = _timer + " Seconds!";
        if (_timer < threeStars && Player.currentHealth > healthThreeStars)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else if (_timer <= twoStars && Player.currentHealth > healthTwoStars)
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
