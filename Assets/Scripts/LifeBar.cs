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
        PlayerControl.onPlayerHeal += UpdateLife;
        PlayerControl.onPlayerTakeHit += UpdateLife;
        UpdateLife();
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
