using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image Panel; // 적용할 이미지 
    public GameObject BlackCanvas;
    float time = 0f; //  시간 변수
    float f_time = 1f; // 페이드인 시간
    [SerializeField]
    GameObject ContorlUI;

    private void Start()
    {
        Fade();
    }

    public void Fade()
    {
        StartCoroutine(FadeFloe());
    }


    // 이미지의 투명도를 받아와 이를 이용해 Fade In -> Fade Out
    IEnumerator FadeFloe()
    {
        Panel.gameObject.SetActive(true); // 이미지를 활성화
        time = 0f;  //  시간을 0초로 초기화
        Color alpha = Panel.color; //  색상 변수 alpha에 세팅된 이미지의 색상값을 적용

        while (alpha.a < 1f) // 반복문 (색상 값이 1보다 작아질때 까지)
        {
            // 흘러가는 시간을 1초로 나눈 후 색상 변수 alpha에 적용
            time += Time.deltaTime / f_time;
            alpha.a = Mathf.Lerp(1, 0, time);

            //그 후 세팅된 이미지의 투명도로 적용하기 위해 alpha값을 적용
            Panel.color = alpha;
            yield return null;

            //반복문을 빠져나오기 위해 색상 값이 0이 된다면 빠져나옴
            if (alpha.a == 0f)
            {
                Script_PlayerControl.instance.ContorlActive = true;
                break;
            }
        }
        //그 후 세팅된 이미지를 비활성화
        BlackCanvas.SetActive(false);
        Panel.gameObject.SetActive(false);
        
        yield return null;

    }
}
