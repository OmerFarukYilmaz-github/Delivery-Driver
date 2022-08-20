using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryController : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay=0.5f;
    SpriteRenderer spriteRenderer;

    public void Start()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Package" && !hasPackage)
        {
            Debug.Log("Package Picked up");
            hasPackage = true;

            spriteRenderer.color= other.gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage && (spriteRenderer.color==other.GetComponent<SpriteRenderer>().color))
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = Color.white;
            UIController.instance.score += 1;
        }

     
    }



}
