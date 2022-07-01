using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            Destroy(col.gameObject);
        }
    }
}
