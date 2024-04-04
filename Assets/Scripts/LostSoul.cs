using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LostSoul : MonoBehaviour
{
    public static event Action<LostSoul> onLostSoulFreed;
    public int nbRewards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Judgement"))
        {
            onLostSoulFreed?.Invoke(this);
        }
    }
}
