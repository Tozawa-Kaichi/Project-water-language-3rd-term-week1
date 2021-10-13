using UnityEngine;

public class SpaceShipController2D : MonoBehaviour
{
    [SerializeField] GameObject m_BulletPrefab = default;
    [SerializeField] Transform m_MuzzlePosition = default;
    [SerializeField] float _speed = 1f;
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h,v);
        _rb.velocity = dir.normalized * _speed;
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(m_BulletPrefab,m_MuzzlePosition.position,this.transform.rotation);
        }
    }
}
