using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelMovement : MonoBehaviour
{
    public float Acceleration = 3000.0f;
    public float SpeedMax = 2000.0f;
    public float SymbolSize = 250.0f;

    [SerializeField] private SlotGame _game;
    [SerializeField] private int _symbolCountInReel;

    private bool _inSpin = false;
    private float _speed = 0.0f;
    private float _minimumRotationDistance = 0.0f;
    private float _reelCorrectionSpeed = 2.0f;

    public void Spin()
    {
        _speed = 0.0f;
        _inSpin = true;
        _minimumRotationDistance = _game.MinimumRotateDistance;
        ChangeSymbol();
    }

    public void ChangeSymbol()
    {
        int index = 0;
        for(int i = 0; i < _symbolCountInReel; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
            index = Random.Range(0, 12);
            GameObject go = ObjectPool.Spawn(index);
            Instantiate(go,transform);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inSpin) return;

        float dt = Mathf.Min(Time.deltaTime, 0.1f);
        Vector3 vPos = transform.localPosition;

        if (_minimumRotationDistance <= 0.0f)
        {
            // reel corrects position
            if ((int)vPos.y != 0)
            {
                vPos.y = Mathf.Lerp(vPos.y, 0.0f, _reelCorrectionSpeed * Time.deltaTime);
            }
        }
        else
        {
            // increase Reel spin speed
            _speed += Acceleration * dt;
            if (_speed >= SpeedMax)
                _speed = SpeedMax;

            // reels move down
            float fDelta = _speed * dt;
            vPos.y -= fDelta;

            _minimumRotationDistance -= fDelta;

            // if Symbol id lower than SymbolSize, move up
            if (vPos.y < -SymbolSize)
            {
                vPos.y += SymbolSize;
            }
        }
        transform.localPosition = vPos;
    }
}
