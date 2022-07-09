using UnityEngine;

public class RayShooter : MonoBehaviour {

    [SerializeField]
    private GameObject _owner;
    [SerializeField]
    private GameObject _bulletPrefab;

    private Camera _camera;

    void Start() {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnGUI() {
        int size = 100;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.skin.label.fontSize = 100;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            var bullet = Shoot(transform.forward, 30, transform.position + (transform.right / 3) + Vector3.down / 4);
            bullet.transform.forward = transform.forward;
        }
    }

    private GameObject Shoot(Vector3 direction, float speed, Vector3 spawnPosition = default(Vector3)) {
        var bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = spawnPosition;
        var bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.Velocity = direction * speed;
        bulletComponent.RotationVelocity = Vector3.forward * Random.Range(-360, 360);

        return bullet;
    }
}
