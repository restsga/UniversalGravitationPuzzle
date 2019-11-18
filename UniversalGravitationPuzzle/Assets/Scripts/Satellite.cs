using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

    public static GameObject[] planets;
    private static float G = 6.67408f / 100;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        foreach (GameObject planet in planets)
        {
            Vector2 direction = planet.transform.position - this.transform.position;
            float distance = direction.magnitude;

            float gravity = G * planet.GetComponent<Rigidbody2D>().mass * this.GetComponent<Rigidbody2D>().mass
                / (distance * distance);
            this.GetComponent<Rigidbody2D>().AddForce(gravity * direction.normalized, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
