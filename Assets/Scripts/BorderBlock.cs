using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBlock : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D col)
    {

        if (this.CompareTag("Border")) return;
        Destroy(col.gameObject);
    }
}
