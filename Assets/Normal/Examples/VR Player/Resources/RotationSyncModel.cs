using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class RotationSyncModel
{
    [RealtimeProperty(3,true,true)]
    Quaternion _rotation;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class RotationSyncModel : RealtimeModel {
    public UnityEngine.Quaternion rotation {
        get {
            return _rotationProperty.value;
        }
        set {
            if (_rotationProperty.value == value) return;
            _rotationProperty.value = value;
            InvalidateReliableLength();
            FireRotationDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(RotationSyncModel model, T value);
    public event PropertyChangedHandler<UnityEngine.Quaternion> rotationDidChange;
    
    public enum PropertyID : uint {
        Rotation = 3,
    }
    
    #region Properties
    
    private ReliableProperty<UnityEngine.Quaternion> _rotationProperty;
    
    #endregion
    
    public RotationSyncModel() : base(null) {
        _rotationProperty = new ReliableProperty<UnityEngine.Quaternion>(3, _rotation);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _rotationProperty.UnsubscribeCallback();
    }
    
    private void FireRotationDidChange(UnityEngine.Quaternion value) {
        try {
            rotationDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _rotationProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _rotationProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Rotation: {
                    changed = _rotationProperty.Read(stream, context);
                    if (changed) FireRotationDidChange(rotation);
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
        _rotation = rotation;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
