using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testdamge : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.transform.name);
        other.transform.GetComponentInParent<IDamageable>().TakeDamage(1);
    }
}
