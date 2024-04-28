using UnityEngine;
using System;

public class LostSoul : MonoBehaviour
{
    public static event Action<LostSoul> onLostSoulFreed;
    public int nbRewards;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Judgement"))
        {
            onLostSoulFreed?.Invoke(this);
        }
    }
}
