using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private AudioClip _audioPickUpSound;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && 
            Input.GetKeyDown(KeyCode.E))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                AudioSource.PlayClipAtPoint(_audioPickUpSound, transform.position, 1f);
                player.CollectTheCoin();
                Destroy(this.gameObject);
            }
        }
    }

}
