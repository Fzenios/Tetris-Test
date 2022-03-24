using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScr : MonoBehaviour
{
    [SerializeField] Vector2 ExplodeDirection;
    void Start()
    {
        Rigidbody2D ExplodRb = GetComponent<Rigidbody2D>();
        ExplodRb.AddForce(ExplodeDirection, ForceMode2D.Impulse);
        Destroy(gameObject, 2);
    }
}
