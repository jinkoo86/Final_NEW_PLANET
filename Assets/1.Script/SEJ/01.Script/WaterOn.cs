using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOn : MonoBehaviour {
    public GameObject water;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        water.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1.0f);
        water.SetActive(false);
    }

    public void OnParticleTrigger() {
        Debug.Log("Debug");
    }
}
