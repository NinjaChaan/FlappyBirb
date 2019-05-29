using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -50) {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            rb.AddForce(new Vector2(0, 100), ForceMode2D.Impulse);
        } else {
            rb.AddForce(new Vector2(0, -2.5f), ForceMode2D.Impulse);
        }
    }

    void Die() {
        gameObject.SetActive(false);
        GameManager.instance.ShowEndScreen();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("paw")) {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("point")) {
            GameManager.instance.GainPoint();
        }
    }
}
