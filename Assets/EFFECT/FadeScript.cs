using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image Panel; // ������ �̹��� 
    public GameObject BlackCanvas;
    float time = 0f; //  �ð� ����
    float f_time = 1f; // ���̵��� �ð�
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


    // �̹����� ������ �޾ƿ� �̸� �̿��� Fade In -> Fade Out
    IEnumerator FadeFloe()
    {
        Panel.gameObject.SetActive(true); // �̹����� Ȱ��ȭ
        time = 0f;  //  �ð��� 0�ʷ� �ʱ�ȭ
        Color alpha = Panel.color; //  ���� ���� alpha�� ���õ� �̹����� ������ ����

        while (alpha.a < 1f) // �ݺ��� (���� ���� 1���� �۾����� ����)
        {
            // �귯���� �ð��� 1�ʷ� ���� �� ���� ���� alpha�� ����
            time += Time.deltaTime / f_time;
            alpha.a = Mathf.Lerp(1, 0, time);

            //�� �� ���õ� �̹����� ������ �����ϱ� ���� alpha���� ����
            Panel.color = alpha;
            yield return null;

            //�ݺ����� ���������� ���� ���� ���� 0�� �ȴٸ� ��������
            if (alpha.a == 0f)
            {
                Script_PlayerControl.instance.ContorlActive = true;
                break;
            }
        }
        //�� �� ���õ� �̹����� ��Ȱ��ȭ
        BlackCanvas.SetActive(false);
        Panel.gameObject.SetActive(false);
        
        yield return null;

    }
}
