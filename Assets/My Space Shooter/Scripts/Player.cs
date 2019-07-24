using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float x_Min, x_Max, z_Min, z_Max;
}



public class Player : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;
	// Use this for initialization

    public GameObject shot;
    public Transform shotspawn;
    public float firerate;

    private float nextfire=0.0F;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;

            Instantiate(shot, shotspawn.position, shotspawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);


        GetComponent<Rigidbody>().position = new Vector3
        (
        Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.x_Min, boundary.x_Max),
        0.0f,
        Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.z_Min, boundary.z_Max)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * (-tilt));
        

    }
}
