using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private GameObject _destroyParticles;

    public Vector3 Velocity;
    public Vector3 RotationVelocity;

    private void Start() {
        Destroy(gameObject, 5);
    }

    private void Update() {
        transform.Translate(Velocity * Time.deltaTime, Space.World);
        transform.Rotate(RotationVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }

    private void OnDestroy() {
        var particles = Instantiate(_destroyParticles);
        particles.transform.position = transform.position;
    }

}
