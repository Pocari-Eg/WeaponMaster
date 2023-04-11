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

    
    
    // 설정된 색상 적용
    void Update()
    {        
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

        // 보간을 통해 색상 값, 0, 시간이 * 사이즈가 커지는 시간을 이용해 색상 값의 투명도를 적용
        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * colorSpeed);
        sprite.color = color;

        // 시간이 지남에 따라 생성된 이펙트의 색상 값이 0.01f 보다 작다면 오브젝트 삭제
        if (sprite.color.a <= 0.01f)
            Destroy(gameObject);        
    }
}
