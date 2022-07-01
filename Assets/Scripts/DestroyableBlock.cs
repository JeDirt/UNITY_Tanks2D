using System;
using UnityEngine;

public class DestroyableBlock : MonoBehaviour
{

    public SpriteRenderer blockSpriteRenderer;
    private Int32 _hitCount;
    
    [Tooltip("After this number of hits block is gotta be destroyed")]
    public Int32 hitsCountToDestroy = 3;
    
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (!col.gameObject.CompareTag("Projectile")) return;
        
        ++_hitCount;
        // Change opacity of the material every hit 
        var material = blockSpriteRenderer.material;
        material.color = new Color(material.color.r,
            material.color.b, material.color.b, material.color.a - 0.3f);

        if (_hitCount != hitsCountToDestroy)
        {
            Destroy(col.gameObject);
            return;
        }

        Destroy(gameObject);
        Destroy(col.gameObject);

    }
    
}
