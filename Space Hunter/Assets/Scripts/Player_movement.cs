using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax,yMin,yMax;
}

public class Player_movement : MonoBehaviour
{
    public Joystick joystick;
    public Shoot_Button shoot_button;

    public Boundary boundary;
    
    public float speed;

    public GameObject Shot;
    public Transform Shot_Spawn;
    public float fireRate;
    private float nextFire;

    public float tilt;

    void Update()
    {
                
        if (shoot_button.Pressed && Time.time > nextFire) {            
            nextFire = Time.time + fireRate;
            Instantiate(Shot, Shot_Spawn.position, Shot_Spawn.rotation);
            GetComponent<AudioSource>().Play();
          }        
    }
    private void FixedUpdate()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed);
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)

        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(-90, 0.0f, (-90-GetComponent<Rigidbody>().velocity.x * -tilt));
    }

}
