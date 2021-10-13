using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    void OnEnable()
    {
        // マウスカーソルを消すには、以下の行をアンコメントする
        // Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.visible = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        this.transform.position = mousePosition;
    }
}
