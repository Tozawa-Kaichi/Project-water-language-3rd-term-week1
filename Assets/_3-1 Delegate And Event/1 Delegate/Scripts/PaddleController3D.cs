using UnityEngine;

public class PaddleController3D : MonoBehaviour
{
    [SerializeField] float _speed = 1.5f;
    Rigidbody _rb = default;
    Rigidbody _anrb;
    PauseManager3D _pauseManager = default;
    Vector3 speed;
    float k=1;
    void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager3D>();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = this.transform.right * _speed * h*k;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Rigidbody が衝突したら消す
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb)
        {
            Destroy(rb.gameObject);
        }
    }

    void OnEnable()
    {
        _pauseManager.OnPauseResume += PauseResume;
    }
    void OnDisable()
    {
        _pauseManager.OnPauseResume -= PauseResume;
    }

    void PauseResume(bool isPause)
    {
        if (isPause)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        
        speed = _rb.velocity ;
        k = 0;
        _rb.Sleep();
    }

    public void Resume()
    {
        _rb.WakeUp();
        k = 1;
        _rb.velocity = speed;
    }
}
