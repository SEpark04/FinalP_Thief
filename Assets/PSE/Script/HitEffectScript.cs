using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HitEffectScript : MonoBehaviour
{
    [SerializeField] private float vig_speed;
    private Volume volume;
    private Vignette vig;
    private DepthOfField dep;
    public static HitEffectScript instance;
    private bool Is_On_corutine = false;

    void Start()
    {
        instance = this;  // 싱글턴
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vig);
        volume.profile.TryGet(out dep);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.H) && Is_On_corutine == false)  // 작동 테스트용
        {
            StartCoroutine(Hit_Effect());
        }
        */
    }

    IEnumerator Hit_Effect()
    {
        vig.active = true;
        Is_On_corutine = true;
        dep.active = true;
        vig.intensity.value = 0f;
        dep.focalLength.value = 0;

        for (float i = 0; vig.intensity.value <= 0.3f; i++)
        {
            vig.intensity.value += vig_speed * Time.smoothDeltaTime;
            dep.focalLength.value += 100 * vig_speed * Time.smoothDeltaTime;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.05f);

        for (float i = 0; vig.intensity.value >= 0.01f; i++)
        {
            vig.intensity.value -= vig_speed * Time.smoothDeltaTime;
            dep.focalLength.value -= 100 * vig_speed * Time.smoothDeltaTime;
            yield return new WaitForSeconds(0.02f);
        }
        vig.active = false;
        dep.active = false;
        Is_On_corutine = false;
        yield return null;
    }

    // 다른 스크립트에서 불러내서 사용 가능
    public void HitEffect()
    {
        StartCoroutine(Hit_Effect());
    }
}
