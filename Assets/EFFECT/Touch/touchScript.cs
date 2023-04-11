using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchScript : MonoBehaviour
{
    SpriteRenderer sprite; 
    Vector2 dir;
    public float moveSpeed = 0.1f;    
    public float Size = 10f;
    public float sizeSpeed = 1f;
    public Color[] colors;
    public float colorSpeed = 5f;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
        transform.localScale = new Vector2(Size, Size);

    }

    
    
    // ������ ���� ����
    void Update()
    {        
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

        // ������ ���� ���� ��, 0, �ð��� * ����� Ŀ���� �ð��� �̿��� ���� ���� ������ ����
        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * colorSpeed);
        sprite.color = color;

        // �ð��� ������ ���� ������ ����Ʈ�� ���� ���� 0.01f ���� �۴ٸ� ������Ʈ ����
        if (sprite.color.a <= 0.01f)
            Destroy(gameObject);        
    }
}
