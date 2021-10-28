using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class PlayerStatsSyncModel
{
    //Realtime Property to sync
    //Arguments: ID, Reliable/Unreliable, Change Event

    [RealtimeProperty(1, true, true)]
    private float _health;

    [RealtimeProperty(2, false, true)]
    private float _energy;

    [RealtimeProperty(3, false, true)]
    private bool _isReady;

    [RealtimeProperty(4, false, true)]
    private int _team;

    [RealtimeProperty(5, false, true)]
    private bool _isServer;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class PlayerStatsSyncModel : RealtimeModel {
    public float energy {
        get {
            return _energyProperty.value;
        }
        set {
            if (_energyProperty.value == value) return;
            _energyProperty.value = value;
            InvalidateUnreliableLength();
            FireEnergyDidChange(value);
        }
    }
    
    public bool isReady {
        get {
            return _isReadyProperty.value;
        }
        set {
            if (_isReadyProperty.value == value) return;
            _isReadyProperty.value = value;
            InvalidateUnreliableLength();
            FireIsReadyDidChange(value);
        }
    }
    
    public int team {
        get {
            return _teamProperty.value;
        }
        set {
            if (_teamProperty.value == value) return;
            _teamProperty.value = value;
            InvalidateUnreliableLength();
            FireTeamDidChange(value);
        }
    }
    
    public bool isServer {
        get {
            return _isServerProperty.value;
        }
        set {
            if (_isServerProperty.value == value) return;
            _isServerProperty.value = value;
            InvalidateUnreliableLength();
            FireIsServerDidChange(value);
        }
    }
    
    public float health {
        get {
            return _healthProperty.value;
        }
        set {
            if (_healthProperty.value == value) return;
            _healthProperty.value = value;
            InvalidateReliableLength();
            FireHealthDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(PlayerStatsSyncModel model, T value);
    public event PropertyChangedHandler<float> healthDidChange;
    public event PropertyChangedHandler<float> energyDidChange;
    public event PropertyChangedHandler<bool> isReadyDidChange;
    public event PropertyChangedHandler<int> teamDidChange;
    public event PropertyChangedHandler<bool> isServerDidChange;
    
    public enum PropertyID : uint {
        Health = 1,
        Energy = 2,
        IsReady = 3,
        Team = 4,
        IsServer = 5,
    }
    
    #region Properties
    
    private ReliableProperty<float> _healthProperty;
    
    private UnreliableProperty<float> _energyProperty;
    
    private UnreliableProperty<bool> _isReadyProperty;
    
    private UnreliableProperty<int> _teamProperty;
    
    private UnreliableProperty<bool> _isServerProperty;
    
    #endregion
    
    public PlayerStatsSyncModel() : base(null) {
        _healthProperty = new ReliableProperty<float>(1, _health);
        _energyProperty = new UnreliableProperty<float>(2, _energy);
        _isReadyProperty = new UnreliableProperty<bool>(3, _isReady);
        _teamProperty = new UnreliableProperty<int>(4, _team);
        _isServerProperty = new UnreliableProperty<bool>(5, _isServer);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _healthProperty.UnsubscribeCallback();
    }
    
    private void FireHealthDidChange(float value) {
        try {
            healthDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireEnergyDidChange(float value) {
        try {
            energyDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireIsReadyDidChange(bool value) {
        try {
            isReadyDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeamDidChange(int value) {
        try {
            teamDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireIsServerDidChange(bool value) {
        try {
            isServerDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _healthProperty.WriteLength(context);
        length += _energyProperty.WriteLength(context);
        length += _isReadyProperty.WriteLength(context);
        length += _teamProperty.WriteLength(context);
        length += _isServerProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _healthProperty.Write(stream, context);
        writes |= _energyProperty.Write(stream, context);
        writes |= _isReadyProperty.Write(stream, context);
        writes |= _teamProperty.Write(stream, context);
        writes |= _isServerProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Health: {
                    changed = _healthProperty.Read(stream, context);
                    if (changed) FireHealthDidChange(health);
                    break;
                }
                case (uint) PropertyID.Energy: {
                    changed = _energyProperty.Read(stream, context);
                    if (changed) FireEnergyDidChange(energy);
                    break;
                }
                case (uint) PropertyID.IsReady: {
                    changed = _isReadyProperty.Read(stream, context);
                    if (changed) FireIsReadyDidChange(isReady);
                    break;
                }
                case (uint) PropertyID.Team: {
                    changed = _teamProperty.Read(stream, context);
                    if (changed) FireTeamDidChange(team);
                    break;
                }
                case (uint) PropertyID.IsServer: {
                    changed = _isServerProperty.Read(stream, context);
                    if (changed) FireIsServerDidChange(isServer);
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
        _health = health;
        _energy = energy;
        _isReady = isReady;
        _team = team;
        _isServer = isServer;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
