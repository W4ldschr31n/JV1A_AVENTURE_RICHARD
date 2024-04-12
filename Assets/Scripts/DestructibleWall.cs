using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public void GetHit()
    {
        Destroy(gameObject);
    }
}
