using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, 0, 30 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            FindObjectOfType<AudioManager>().playSound("PickupGem");
            Destroy(gameObject);
            PlayerManager.numGems += 1;
            
        }
    }
}
