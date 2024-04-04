using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faith : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Aîe");
        if (
            collision.gameObject.CompareTag("Player")
            &&
            !collision.gameObject.GetComponent<PlayerControl>().IsFullLife()
        )
        {
            collision.gameObject.GetComponent<PlayerControl>().TakeFaith();
            Destroy(gameObject);
        }
    }
}
