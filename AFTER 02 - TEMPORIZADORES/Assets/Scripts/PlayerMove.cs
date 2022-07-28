using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    // Start is called before the first frame update
    public GameObject munition;

    Vector3 directionPlayer;

    public bool canShoot = true;
    public float cooldown = 2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /* PRIMERA FORMA DE MOVIMIENTO
        directionPlayer = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {

            directionPlayer += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            directionPlayer += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            directionPlayer += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            directionPlayer += Vector3.right;
        }

        if (directionPlayer != Vector3.zero)
        {
            Debug.Log(directionPlayer);
            MovePlayer(directionPlayer);
        }
        */
        // SEGUNDA FORMA DE MOVIMIENTO
        MoveAxis();
        //DISPARO CON TEMPORIZADOR
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (canShoot)
            {
                canShoot = false;
                Shoot();
                Invoke("ResetShoot", cooldown);
            }
        }

    }

    private void ResetShoot()
    {
        canShoot = true;
    }

    private void MoveAxis()
    {
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(ejeHorizontal, 0, ejeVertical);
        transform.Translate(direction * speed * Time.deltaTime);
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
