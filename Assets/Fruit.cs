using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //Fruit Variables
    public GameObject wholeFruit;
    private GameObject fruitThrowing;

    //push Fruit Variables
    public float minVerticalForce=50;
    public float maxVerticalForce=200;
    public float minHorizontalForce = 50;
    public float maxHorizontalForce = 200;
    private float verticalforce;
    private float horizontalforce;
    private float throwingDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        //set forces
        verticalforce = Random.Range(minVerticalForce, maxVerticalForce);
        horizontalforce = Random.Range(minHorizontalForce, maxHorizontalForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showWholeFruit()
    {
        fruitThrowing = Instantiate(wholeFruit);

        fruitThrowing.transform.position = transform.position;

        setThrowingDirection();

        fruitThrowing.GetComponent<Rigidbody>().AddForce(
            new Vector3(
                horizontalforce*throwingDirection,
                verticalforce,
                0
                )
            );
    }

    void setThrowingDirection()
    {
        if (Random.value > 0.5)
            throwingDirection = 1;
        else
            throwingDirection = -1;
    }
}
