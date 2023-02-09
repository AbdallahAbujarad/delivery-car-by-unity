using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class collision : MonoBehaviour
{
    Color32 hasPackageColor = new Color32(0,255,0,255);
    Color32 noPackageColor = new Color32(255, 255, 255, 255);
    int packageNum = 1;
    [SerializeField] float delayTime = 0.5f;
    bool hasPicked;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }


    void OnCollisionEnter2D()
    {
        Debug.Log("ouch!!");
        spriteRenderer.color = spriteRenderer.color - new Color32(0,0,0,30);

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Package" && hasPicked)
        {
            Debug.Log("you already have picked a package");
        }


        if (other.tag == "Package" && !hasPicked) {
            Debug.Log("package " + packageNum + " picked up");
            hasPicked = true;
            Destroy(other.gameObject,delayTime);
            spriteRenderer.color = hasPackageColor;
        }


        if (other.tag == "Customer" && !hasPicked && packageNum < 4)
        {
            Debug.Log("get a package first");
        }

        if (other.tag == "Customer" && !hasPicked && packageNum == 4)
        {
            Debug.Log("you picked up and delivered all the packages");
        }

        if (other.tag == "Customer" && hasPicked )
        {
            Debug.Log("package dilevered");
            hasPicked = false;
            packageNum++;
            spriteRenderer.color = noPackageColor;
        }
    }
}
