using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float duration = 1f;
    public int damage = 50;

    // This function is called when the object becomes enabled and active
    private void OnEnable()
    {
        // Start timer
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(duration);
        // Disable the game object after duration
        gameObject.SetActive(false);
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Detect enemy
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            // Deal damage
            enemy.DealDamage(damage);
            // Disable weapon
            gameObject.SetActive(false);
        }
    }
}
