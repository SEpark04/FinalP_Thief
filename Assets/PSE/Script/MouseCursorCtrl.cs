using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursorCtrl : MonoBehaviour
{
    public static MouseCursorCtrl Instance; // 싱글턴 인스턴스


    void Awake()
    {
        // 싱글톤 패턴
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않음
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 이름에 따라 커서 설정
        if (scene.name == "Title") // 타이틀 화면
        {
            SetCursorVisible(true, CursorLockMode.None);
        }
        else if (scene.name == "LoadingScene") // 로딩 화면
        {
            SetCursorVisible(false, CursorLockMode.Locked);
        }
        else if (scene.name == "Map") // 인게임
        {
            SetCursorVisible(false, CursorLockMode.Locked);
        }
    }
    
    //마우스커서 보이게 안 보이게 
    public void SetCursorVisible(bool visible, CursorLockMode lockMode)
    {
        Cursor.visible = visible;
        Cursor.lockState = lockMode;
    }
}
