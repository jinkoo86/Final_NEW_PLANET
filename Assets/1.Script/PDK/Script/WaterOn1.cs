using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOn1 : MonoBehaviour {
    public GameObject water;
    public GameObject waterCup;
    GameObject cupFactory;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "CUP") {
            other.transform.rotation = Quaternion.Euler(Vector3.zero);
            other.transform.position = transform.position + new Vector3(0, 0.05f, 0);
            water.SetActive(true);
            StartCoroutine(Wait());
            Destroy(other.gameObject, 0);
            cupFactory = Instantiate(waterCup);
            cupFactory.transform.position = transform.position + new Vector3(0, 0.05f, 0);
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1.0f);
        water.SetActive(false);
    }
}
