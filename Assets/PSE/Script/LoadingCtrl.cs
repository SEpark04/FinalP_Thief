using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingCtrl : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image loadingBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation aop = SceneManager.LoadSceneAsync(nextScene);
        aop.allowSceneActivation = false;

        float timer = 0f;
        while (!aop.isDone)
        {
            yield return null;

            if(aop.progress > 0.9f)  //90% ����
            {
                //�ε� ���൵�� ���� �ε��ٰ� ä����
                loadingBar.fillAmount = aop.progress;
            }
            else  //90% ����
            {
                //����ũ �ε�. 10%�� 1�ʰ� ä�� �� ���� �ҷ���.
                timer += Time.unscaledDeltaTime;
                loadingBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(loadingBar.fillAmount >= 1f)
                {
                    aop.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
