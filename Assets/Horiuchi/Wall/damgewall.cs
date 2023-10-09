using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damgewall : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        other.transform.GetComponentInParent<IDamageable>().TakeDamage(1);
    }
}
