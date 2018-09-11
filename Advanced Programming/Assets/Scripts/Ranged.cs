using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    public float range = 25f;
    public int damage = 15;
    public float duration = 0.5f;

    public Enemy enemy;

    private void OnEnable()
    {
        RaycastHit ray;
        if(Physics.Raycast(transform.position, transform.forward, out ray, range))
        {
            if (ray.collider.gameObject.CompareTag("Enemy"))
            {
                enemy = ray.collider.gameObject.GetComponent<Enemy>();
                DealDamage(enemy);
            }
        }
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

    public void DealDamage(Enemy enemy)
    {
        enemy.DealDamage(damage);
        Debug.Log("Dealt " + damage + " damage " + " to " + enemy.name);
        gameObject.SetActive(false);
    }
}
