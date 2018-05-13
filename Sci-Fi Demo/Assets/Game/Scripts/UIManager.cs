using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private GameObject _coin;

	public void UpdateAmoTitle(int ammoCount)
    {
        _ammoText.text = "Ammo: " + ammoCount;
    }

    public void CollectedCoin()
    {
        _coin.SetActive(true);
    }
}
