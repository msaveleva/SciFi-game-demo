using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float kGravity = 9.81f;

	[SerializeField]
	private float _speed = 3.5f;
    [SerializeField]
    private int _currentAmo;
    [SerializeField]
    private float _reloadTimeout = 1.5f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarker;
    [SerializeField]
    private AudioSource _weapoAudio;

	private CharacterController _charaController;
    private UIManager _uiManager;

    private int _maxAmo = 50;
    private bool _isReloading = false;
    private int _numberOfCoins = 0;

    // Use this for initialization
    void Start () {
		_charaController = GetComponent<CharacterController> ();

        Cursor.lockState = CursorLockMode.Locked;
        _currentAmo = _maxAmo;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.Mouse0) && _currentAmo > 0)
        {
            _Shoot();
        }
        else
        {
            _weapoAudio.Stop();
            _muzzleFlash.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(_Reload());
        }

        _MovePlayer();
	}

    public void CollectTheCoin()
    {
        _numberOfCoins++;
        _uiManager.CollectedCoin();
    }

    void _Shoot()
    {
        _currentAmo--;
        _uiManager.UpdateAmoTitle(_currentAmo);

        if (!_weapoAudio.isPlaying)
        {
            _weapoAudio.Play();
        }

        _muzzleFlash.SetActive(true);

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit raycastHitInfo;
        if (Physics.Raycast(rayOrigin, out raycastHitInfo))
        {
            //Debug.Log("Hit: " + raycastHitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarker, raycastHitInfo.point, Quaternion.LookRotation(raycastHitInfo.normal)) as GameObject;
            Destroy(hitMarker, 0.2f);
        }
    }

    IEnumerator _Reload()
    {
        yield return new WaitForSeconds(_reloadTimeout);
        _currentAmo = _maxAmo;
        _uiManager.UpdateAmoTitle(_currentAmo);
        _isReloading = false;
        Debug.Log("Reloaded");
    }

    void _MovePlayer() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= kGravity;

        //transform to global coordinates.
        velocity = transform.transform.TransformDirection(velocity);

        _charaController.Move(velocity * Time.deltaTime);
    }
}
