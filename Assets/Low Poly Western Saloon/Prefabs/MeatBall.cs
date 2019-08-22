using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBall : MonoBehaviour
{
    public int MeatBallSpeed = 100;
    public int damage = 3;

    // Update is called once per frame
    void Update()
    {
        //Move along the 'X' Axis
        transform.Translate(MeatBallSpeed * Time.deltaTime, 0, 0, Space.Self);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Sam"))
        {
            other.gameObject.GetComponent<RedCharacter>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag.Equals("Harry"))
        {
            other.gameObject.GetComponent<BlueCharacter>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
