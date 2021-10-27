using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class AmmoStatsSyncModel {
	[RealtimeProperty(1, true, true)]
	private int _ammo; 
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class AmmoStatsSyncModel : RealtimeModel {
    public int ammo {
        get {
            return _ammoProperty.value;
        }
        set {
            if (_ammoProperty.value == value) return;
            _ammoProperty.value = value;
            InvalidateReliableLength();
            FireAmmoDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(AmmoStatsSyncModel model, T value);
    public event PropertyChangedHandler<int> ammoDidChange;
    
    public enum PropertyID : uint {
        Ammo = 1,
    }
    
    #region Properties
    
    private ReliableProperty<int> _ammoProperty;
    
    #endregion
    
    public AmmoStatsSyncModel() : base(null) {
        _ammoProperty = new ReliableProperty<int>(1, _ammo);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _ammoProperty.UnsubscribeCallback();
    }
    
    private void FireAmmoDidChange(int value) {
        try {
            ammoDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _ammoProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _ammoProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Ammo: {
                    changed = _ammoProperty.Read(stream, context);
                    if (changed) FireAmmoDidChange(ammo);
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
        _ammo = ammo;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
