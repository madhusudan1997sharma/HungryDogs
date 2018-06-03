using UnityEngine;
using System.Collections;

public class Instantiater : MonoBehaviour {

    public GameObject[] items;
    public int side;

	// Use this for initialization
	void Start () {
        int rate = Random.Range(3, 6);
        Invoke("InstantiaterFunction", rate);
	}
	
	void InstantiaterFunction()
    {
        int itemNumber = Random.Range(0, 10);
        if (itemNumber <= 6)
            itemNumber = 0;
        else
            itemNumber = 1;
        GameObject obj = GameObject.Instantiate(items[itemNumber], transform.position, Quaternion.identity) as GameObject;

        obj.GetComponent<Rigidbody2D>().velocity = transform.right.normalized * 10 * side;
        Destroy(obj, 2);

        int rate = Random.Range(1, 4);
        Invoke("InstantiaterFunction", rate);
    }
}
