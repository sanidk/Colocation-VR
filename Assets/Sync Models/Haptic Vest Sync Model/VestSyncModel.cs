using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class VestSyncModel
{
    [RealtimeProperty(1, false, true)]
    private int _actuator;

    [RealtimeProperty(2, false, true)]
    private int _time;

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class VestSyncModel : RealtimeModel {
    public int actuator {
        get {
            return _actuatorProperty.value;
        }
        set {
            if (_actuatorProperty.value == value) return;
            _actuatorProperty.value = value;
            InvalidateUnreliableLength();
            FireActuatorDidChange(value);
        }
    }
    
    public int time {
        get {
            return _timeProperty.value;
        }
        set {
            if (_timeProperty.value == value) return;
            _timeProperty.value = value;
            InvalidateUnreliableLength();
            FireTimeDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(VestSyncModel model, T value);
    public event PropertyChangedHandler<int> actuatorDidChange;
    public event PropertyChangedHandler<int> timeDidChange;
    
    public enum PropertyID : uint {
        Actuator = 1,
        Time = 2,
    }
    
    #region Properties
    
    private UnreliableProperty<int> _actuatorProperty;
    
    private UnreliableProperty<int> _timeProperty;
    
    #endregion
    
    public VestSyncModel() : base(null) {
        _actuatorProperty = new UnreliableProperty<int>(1, _actuator);
        _timeProperty = new UnreliableProperty<int>(2, _time);
    }
    
    private void FireActuatorDidChange(int value) {
        try {
            actuatorDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTimeDidChange(int value) {
        try {
            timeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _actuatorProperty.WriteLength(context);
        length += _timeProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _actuatorProperty.Write(stream, context);
        writes |= _timeProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Actuator: {
                    changed = _actuatorProperty.Read(stream, context);
                    if (changed) FireActuatorDidChange(actuator);
                    break;
                }
                case (uint) PropertyID.Time: {
                    changed = _timeProperty.Read(stream, context);
                    if (changed) FireTimeDidChange(time);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _actuator = actuator;
        _time = time;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
