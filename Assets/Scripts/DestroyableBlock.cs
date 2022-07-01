using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBlock : MonoBehaviour
{
    public Int32 hitCount = 0;
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        hitCount++;
        Destroy(col.gameObject);
        if (hitCount == 3)
        {
            Destroy(gameObject);
        }
    }
}
