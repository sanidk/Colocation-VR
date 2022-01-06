using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vest : MonoBehaviour
{
    public LedOnOffManager bluetoothManager;
    [SerializeField]
    public int _actuator;
    public int _time;
   
    public int _previousActuator;
    public int _previousTime;

    VestSync _vestSync;

    private void Awake()
    {
        bluetoothManager = GameObject.Find("BTManager").GetComponent<LedOnOffManager>();
        _vestSync = GetComponent<VestSync>();
    }

    private void Update()
    {
        
        if (_actuator != _previousActuator)
        {
            bluetoothManager.sendData(_actuator.ToString());
            _vestSync.SetActuator(_actuator);
            _previousActuator = _actuator;
        }

        if (_time != _previousTime)
        {
            _vestSync.SetTime(_time);
            _previousTime = _time;
        }
    }
}
