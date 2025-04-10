using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    private SpriteRenderer sr;
    public float blinkDuration = 2f;
    public float blinkInterval = 0.1f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(BlinkEffect());
        }
    }

    private System.Collections.IEnumerator BlinkEffect()
    {
        float timer = 0f;
        while (timer < blinkDuration)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }

        sr.enabled = true;
    }
}
