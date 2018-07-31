using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public BoxCollider hitbox;
    public int damage = 50;
    // attribute
    [Tooltip("Duration hitbox is enabled (in seconds)")]
    public float hitDuration = 1f; // duration hitbox is enabled



    // Update is called once per frame
    void Update()
    {
        // check is space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // run hit sequence
            StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        hitbox.enabled = true;
        yield return new WaitForSeconds(hitDuration);
        hitbox.enabled = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        // detect enemy
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {

            // deal damage
            enemy.DealDamage(damage);
        }
    }


}
