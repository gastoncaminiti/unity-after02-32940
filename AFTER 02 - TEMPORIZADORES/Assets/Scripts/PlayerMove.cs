using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    // Start is called before the first frame update
    public GameObject munition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Shoot();
        }

    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Shoot()
    {   
        Debug.Log("DISPARAR");
        Instantiate(munition, transform.position, transform.rotation);
    }
}
