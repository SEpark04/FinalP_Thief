using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursorCtrl : MonoBehaviour
{
    public static MouseCursorCtrl Instance; // �̱��� �ν��Ͻ�

    [SerializeField] Texture2D customCursor; // Ŀ���� Ŀ��
    [SerializeField] Vector2 cursorSpot = Vector2.zero; // Ŀ�� ��ġ

    void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� ����
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
        // �� �̸��� ���� Ŀ�� ����
        if (scene.name == "Title") // Ÿ��Ʋ ȭ��
        {
            SetCursorVisible(true, customCursor, CursorLockMode.None);
        }
        else if (scene.name == "LoadingScene") // �ε� ȭ��
        {
            SetCursorVisible(false, null, CursorLockMode.Locked);
        }
        else if (scene.name == "Map") // �ΰ���
        {
            SetCursorVisible(false, null, CursorLockMode.Locked);
        }
    }

    public void SetCursorVisible(bool visible, Texture2D cursor, CursorLockMode lockMode)
    {
        Cursor.visible = visible;
        Cursor.lockState = lockMode;
        Cursor.SetCursor(cursor, cursorSpot, CursorMode.Auto);
    }
}
