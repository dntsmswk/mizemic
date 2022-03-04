using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [Range(0.0f, 5.0f)]
    public float maxDistance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var vec = transform.position;

        vec += new Vector3(h, v, 0).normalized * moveSpeed * Time.deltaTime;

        // 이동을 위한 값을 갖고 있는 변수의 x,y값의 최대 최소를 준 것 즉 이동 제한
        // 이해가 안되기는 한데 처음 위치 기준으로 최대최소를 정해준듯
        vec.x = Clamp(vec.x, -maxDistance, maxDistance);
        vec.y = Clamp(vec.y, -maxDistance, maxDistance);

        transform.position = vec;
    }
}
