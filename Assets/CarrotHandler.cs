using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarrotHandler: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public AudioClip audioClip;
    private int point = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.name;
        if (player == "player")
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
        }
    }
}