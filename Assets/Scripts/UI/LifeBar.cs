using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private PlayerControl player;
    [SerializeField]
    private Image fill;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateLife()
    {
        fill.fillAmount = (float)player.health/100f;
    }
}
