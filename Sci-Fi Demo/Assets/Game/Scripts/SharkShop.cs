using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {

    [SerializeField]
    private AudioClip _winSound;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && 
            Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Stay on trigger");
            Player player = other.GetComponent<Player>();
            if (player == null)
            {
                return;
            }

            if (player.BuyWeapon())
            {
                AudioSource.PlayClipAtPoint(_winSound, transform.position, 1f);
            }
            else
            {
                Debug.Log("Get out of here criminal scum!");
            }
        }
    }
}
