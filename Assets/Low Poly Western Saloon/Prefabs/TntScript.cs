using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TntScript : MonoBehaviour
{
    public int TntSpeed = 1;
    public int damage = 3;

    // Update is called once per frame
    void Update()
    {
        //Move along the 'X' Axis
        transform.Translate(TntSpeed * Time.deltaTime, 0, 0, Space.Self);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Sam"))
        {
            other.gameObject.GetComponent<CharacterScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag.Equals("Harry"))
        {
            other.gameObject.GetComponent<SecondCharacterScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
