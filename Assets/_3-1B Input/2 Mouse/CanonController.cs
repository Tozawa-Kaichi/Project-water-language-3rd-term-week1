using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] GameObject m_BombPrefab;
    [SerializeField] Transform m_muzzle;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        Vector3 dir = pos - this.transform.position;
        this.transform.right = dir;

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(m_BombPrefab,m_muzzle.position,this.transform.rotation);
        }
    }
}
