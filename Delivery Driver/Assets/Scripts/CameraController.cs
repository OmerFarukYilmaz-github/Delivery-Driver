using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float camDistance=-10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // this.transform.position = new Vector2(target.transform.position.x,target.transform.position.y);
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y,camDistance);
    }
}
