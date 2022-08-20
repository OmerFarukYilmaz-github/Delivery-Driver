using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverController : MonoBehaviour
{
   [SerializeField] float steerSpeed = 200;
   [SerializeField] float movementSpeed = 20;

    [SerializeField] float slowSpeed = 12;
    [SerializeField] float boostSpeed = 30;



    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float movementAmount = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        // 360 derece d�n�p hareket etmek i�in Z eksenini kullan�caz
        if (movementAmount >= 0)
        {
            transform.Rotate(0, 0, -steerAmount);   //kontroller bu �ekilde d�zg�n �al���yor
        }
        else//geri geri giderken sa�-sol tersine �al���yor. onu engellemek i�in
        {
            transform.Rotate(0, 0, steerAmount);
        }

        // belirlenen x,y,z eksenlerinde sonsuz hareket yapt�r�r.
        transform.Translate(0, movementAmount, 0);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("BOOST");
            movementSpeed = boostSpeed;
        }
        if (other.tag == "Bump")
        {
            Debug.Log("BUMP");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        movementSpeed = slowSpeed;
    }
  
}
