using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage; // default is false

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        Debug.Log(hasPackage);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("63410154 Punyarit Klaphachon Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("What was that?!");
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Pickup");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Devliered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

        if (other.tag == "Boost")
        {
            Destroy(other.gameObject, destroyDelay);
        }
    }
}
