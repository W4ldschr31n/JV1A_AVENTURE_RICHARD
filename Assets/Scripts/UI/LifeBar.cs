using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    // External components
    private PlayerControl player;
    [SerializeField]
    private Image fill;

    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        UpdateLife();
    }
    private void OnEnable()
    {
        PlayerControl.onPlayerHeal += UpdateLife;
        PlayerControl.onPlayerTakeHit += UpdateLife;
    }

    private void OnDisable()
    {
        PlayerControl.onPlayerHeal -= UpdateLife;
        PlayerControl.onPlayerTakeHit -= UpdateLife;
    }

    private void UpdateLife()
    {
        fill.fillAmount = (float)player.health/100f;
    }
}
