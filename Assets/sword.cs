using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    //Variables
    public GameObject slicedApple;
    public GameObject slicedBanana;
    public GameObject slicedKiwi;
    public GameObject slicedStrawberry;

    public TextMesh scoretext;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "SLICED")
        {
            string FruitNameHit = collision.gameObject.name;

            //check Name is Fuit Name, show sliced fruit
            if (FruitNameHit.Contains("Apple"))
                showSlicedFuit(slicedApple, collision.gameObject);

            if (FruitNameHit.Contains("Banana"))
                showSlicedFuit(slicedBanana, collision.gameObject);

            if (FruitNameHit.Contains("Kiwi"))
                showSlicedFuit(slicedKiwi, collision.gameObject);

            if (FruitNameHit.Contains("Strawberry"))
                showSlicedFuit(slicedStrawberry, collision.gameObject);
        }

    }

    void showSlicedFuit(GameObject slicedFruitToShow, GameObject wholeFruitToDelete)
    {
        GameObject slicedfruit = Instantiate(slicedFruitToShow, wholeFruitToDelete.transform.position,
            wholeFruitToDelete.transform.rotation);

        slicedfruit.gameObject.name = "SLICED";

        Destroy(wholeFruitToDelete);

        score++;
        scoretext.text = "SCORE: " + score;

    }
}
