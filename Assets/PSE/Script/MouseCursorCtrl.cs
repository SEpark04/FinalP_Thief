using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursorCtrl : MonoBehaviour
{
    public static MouseCursorCtrl Instance; // �̱��� �ν��Ͻ�


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
            SetCursorVisible(true, CursorLockMode.None);
        }
        else if (scene.name == "LoadingScene") // �ε� ȭ��
        {
            SetCursorVisible(false, CursorLockMode.Locked);
        }
        else if (scene.name == "Map") // �ΰ���
        {
            SetCursorVisible(false, CursorLockMode.Locked);
        }
    }
    
    //���콺Ŀ�� ���̰� �� ���̰� 
    public void SetCursorVisible(bool visible, CursorLockMode lockMode)
    {
        Cursor.visible = visible;
        Cursor.lockState = lockMode;
    }
}
