using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMove : MonoBehaviour
{
    [SerializeField] private float _cactusSpeed;
    [SerializeField] private float _limitX;
    [SerializeField] private float _startX;

    private void Update()
    {
        transform.Translate(Vector3.left * _cactusSpeed * Time.deltaTime);

        if(this.transform.position.x < _limitX)
        {
            Destroy(this.gameObject);
        }
        if (GameManager.manager.end == true)
            _cactusSpeed = 0;
    }

    // OnEnable() : Start() �Լ����� ���� ����Ǵ� �ż��� ��ü�� �ʱ�ȭ �����ִ� �Լ�
    private void OnEnable()
    {
        this.transform.position = new Vector3(_startX, Random.Range(-3  ,3), 0);
    }
}
