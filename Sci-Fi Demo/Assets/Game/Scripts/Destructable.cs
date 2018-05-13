using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    [SerializeField]
    private GameObject _destructedCrate;

	public void DestructCrate()
    {
        Instantiate(_destructedCrate, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
