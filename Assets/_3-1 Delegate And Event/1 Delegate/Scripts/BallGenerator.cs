using UnityEngine;

/// <summary>
/// 一定間隔でボールを生成するコンポーネント
/// </summary>
public class BallGenerator : MonoBehaviour
{
    [SerializeField] GameObject _ballPrefab = default;
    [SerializeField] Transform[] _spawnPoints = default;
    [SerializeField] float _interval = 2f;
    float _timer;
    float _pausetime;
    PauseManager3D _pauseManager = default;
    bool pause=false;


    void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager3D>();
    }

    void Start()
    {
        _timer = _interval;
    }

    void OnEnable()
    {
        // 呼んで欲しいメソッドを登録する。
        // 自分を 追加するために+＝
        _pauseManager.OnPauseResume += PauseResume;
    }

    void OnDisable()
    {
        // OnDisable ではメソッドの登録を解除すること。さもないとオブジェクトが無効にされたり破棄されたりした後にエラーになってしまう。
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

    void Update()
    {
        if (pause==false)
        {
            _timer += Time.deltaTime;

            if (_timer > _interval)
            {
                _timer = 0;

                foreach (var p in _spawnPoints)
                {
                    Instantiate(_ballPrefab, p.position, Quaternion.identity);
                }
            }
        }
    }

    public void Pause()
    {
        pause = true;
    }

    public void Resume()
    {
        pause = false;
    }
}
