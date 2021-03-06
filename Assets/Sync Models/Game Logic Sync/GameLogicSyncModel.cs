using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class GameLogicSyncModel
{

    [RealtimeProperty(1, false, true)]
    private int _gameMode;

    [RealtimeProperty(2, false, true)]
    private bool _isPlayersConnectedAndTeamsAssigned;
    
    [RealtimeProperty(3, false, true)]
    private bool _isPlayersReadyToStartGame;

    [RealtimeProperty(4, false, true)]
    private bool _isGameStart; 

    [RealtimeProperty(5, false, true)]
    private bool _isRoundStarted;

    [RealtimeProperty(6, false, true)]
    private int _gameWinner;

    [RealtimeProperty(7, false, true)]
    private int _teamSize;
    
    //List<GameObject> team1players
    //List<GameObject> team2players

    [RealtimeProperty(8, false, true)]
    private float _roundTotalTime;

    [RealtimeProperty(9, false, true)]
    private float _roundStartTime;

    [RealtimeProperty(10, false, true)]
    private float _roundElapsedTime;

    [RealtimeProperty(11, false, true)]
    private int _team1Score;

    [RealtimeProperty(12, false, true)]
    private int _team2Score;

    [RealtimeProperty(13, false, true)]
    private int _roundCurrent;

    [RealtimeProperty(14, false, true)]
    private int _roundsPlayed;

    [RealtimeProperty(15, false, true)]
    private int _roundsTotal;

    [RealtimeProperty(16, false, true)]
    private float _team1Kills;

    [RealtimeProperty(17, false, true)]
    private float _team2Kills;

    [RealtimeProperty(18, false, true)]
    private float _team1TotalKills;

    [RealtimeProperty(19, false, true)]
    private float _team2TotalKills;

    [RealtimeProperty(20, false, true)]
    private float _team1PlayerCount;

    [RealtimeProperty(21, false, true)]
    private float _team2PlayerCount;

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class GameLogicSyncModel : RealtimeModel {
    public int gameMode {
        get {
            return _gameModeProperty.value;
        }
        set {
            if (_gameModeProperty.value == value) return;
            _gameModeProperty.value = value;
            InvalidateUnreliableLength();
            FireGameModeDidChange(value);
        }
    }
    
    public bool isPlayersConnectedAndTeamsAssigned {
        get {
            return _isPlayersConnectedAndTeamsAssignedProperty.value;
        }
        set {
            if (_isPlayersConnectedAndTeamsAssignedProperty.value == value) return;
            _isPlayersConnectedAndTeamsAssignedProperty.value = value;
            InvalidateUnreliableLength();
            FireIsPlayersConnectedAndTeamsAssignedDidChange(value);
        }
    }
    
    public bool isPlayersReadyToStartGame {
        get {
            return _isPlayersReadyToStartGameProperty.value;
        }
        set {
            if (_isPlayersReadyToStartGameProperty.value == value) return;
            _isPlayersReadyToStartGameProperty.value = value;
            InvalidateUnreliableLength();
            FireIsPlayersReadyToStartGameDidChange(value);
        }
    }
    
    public bool isGameStart {
        get {
            return _isGameStartProperty.value;
        }
        set {
            if (_isGameStartProperty.value == value) return;
            _isGameStartProperty.value = value;
            InvalidateUnreliableLength();
            FireIsGameStartDidChange(value);
        }
    }
    
    public bool isRoundStarted {
        get {
            return _isRoundStartedProperty.value;
        }
        set {
            if (_isRoundStartedProperty.value == value) return;
            _isRoundStartedProperty.value = value;
            InvalidateUnreliableLength();
            FireIsRoundStartedDidChange(value);
        }
    }
    
    public int gameWinner {
        get {
            return _gameWinnerProperty.value;
        }
        set {
            if (_gameWinnerProperty.value == value) return;
            _gameWinnerProperty.value = value;
            InvalidateUnreliableLength();
            FireGameWinnerDidChange(value);
        }
    }
    
    public int teamSize {
        get {
            return _teamSizeProperty.value;
        }
        set {
            if (_teamSizeProperty.value == value) return;
            _teamSizeProperty.value = value;
            InvalidateUnreliableLength();
            FireTeamSizeDidChange(value);
        }
    }
    
    public float roundTotalTime {
        get {
            return _roundTotalTimeProperty.value;
        }
        set {
            if (_roundTotalTimeProperty.value == value) return;
            _roundTotalTimeProperty.value = value;
            InvalidateUnreliableLength();
            FireRoundTotalTimeDidChange(value);
        }
    }
    
    public float roundStartTime {
        get {
            return _roundStartTimeProperty.value;
        }
        set {
            if (_roundStartTimeProperty.value == value) return;
            _roundStartTimeProperty.value = value;
            InvalidateUnreliableLength();
            FireRoundStartTimeDidChange(value);
        }
    }
    
    public float roundElapsedTime {
        get {
            return _roundElapsedTimeProperty.value;
        }
        set {
            if (_roundElapsedTimeProperty.value == value) return;
            _roundElapsedTimeProperty.value = value;
            InvalidateUnreliableLength();
            FireRoundElapsedTimeDidChange(value);
        }
    }
    
    public int team1Score {
        get {
            return _team1ScoreProperty.value;
        }
        set {
            if (_team1ScoreProperty.value == value) return;
            _team1ScoreProperty.value = value;
            InvalidateUnreliableLength();
            FireTeam1ScoreDidChange(value);
        }
    }
    
    public int team2Score {
        get {
            return _team2ScoreProperty.value;
        }
        set {
            if (_team2ScoreProperty.value == value) return;
            _team2ScoreProperty.value = value;
            InvalidateUnreliableLength();
            FireTeam2ScoreDidChange(value);
        }
    }
    
    public int roundCurrent {
        get {
            return _roundCurrentProperty.value;
        }
        set {
            if (_roundCurrentProperty.value == value) return;
            _roundCurrentProperty.value = value;
            InvalidateUnreliableLength();
            FireRoundCurrentDidChange(value);
        }
    }
    
    public int roundsPlayed {
        get {
            return _roundsPlayedProperty.value;
        }
        set {
            if (_roundsPlayedProperty.value == value) return;
            _roundsPlayedProperty.value = value;
            InvalidateUnreliableLength();
            FireRoundsPlayedDidChange(value);
        }
    }
    
    public int roundsTotal {
        get {
            return _roundsTotalProperty.value;
        }
        set {
            if (_roundsTotalProperty.value == value) return;
            _roundsTotalProperty.value = value;
            InvalidateUnreliableLength();
            FireRoundsTotalDidChange(value);
        }
    }
    
    public float team1Kills {
        get {
            return _team1KillsProperty.value;
        }
        set {
            if (_team1KillsProperty.value == value) return;
            _team1KillsProperty.value = value;
            InvalidateUnreliableLength();
            FireTeam1KillsDidChange(value);
        }
    }
    
    public float team2Kills {
        get {
            return _team2KillsProperty.value;
        }
        set {
            if (_team2KillsProperty.value == value) return;
            _team2KillsProperty.value = value;
            InvalidateUnreliableLength();
            FireTeam2KillsDidChange(value);
        }
    }
    
    public float team1TotalKills {
        get {
            return _team1TotalKillsProperty.value;
        }
        set {
            if (_team1TotalKillsProperty.value == value) return;
            _team1TotalKillsProperty.value = value;
            InvalidateUnreliableLength();
            FireTeam1TotalKillsDidChange(value);
        }
    }
    
    public float team2TotalKills {
        get {
            return _team2TotalKillsProperty.value;
        }
        set {
            if (_team2TotalKillsProperty.value == value) return;
            _team2TotalKillsProperty.value = value;
            InvalidateUnreliableLength();
            FireTeam2TotalKillsDidChange(value);
        }
    }
    
    public float team1PlayerCount {
        get {
            return _team1PlayerCountProperty.value;
        }
        set {
            if (_team1PlayerCountProperty.value == value) return;
            _team1PlayerCountProperty.value = value;
            InvalidateUnreliableLength();
            FireTeam1PlayerCountDidChange(value);
        }
    }
    
    public float team2PlayerCount {
        get {
            return _team2PlayerCountProperty.value;
        }
        set {
            if (_team2PlayerCountProperty.value == value) return;
            _team2PlayerCountProperty.value = value;
            InvalidateUnreliableLength();
            FireTeam2PlayerCountDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(GameLogicSyncModel model, T value);
    public event PropertyChangedHandler<int> gameModeDidChange;
    public event PropertyChangedHandler<bool> isPlayersConnectedAndTeamsAssignedDidChange;
    public event PropertyChangedHandler<bool> isPlayersReadyToStartGameDidChange;
    public event PropertyChangedHandler<bool> isGameStartDidChange;
    public event PropertyChangedHandler<bool> isRoundStartedDidChange;
    public event PropertyChangedHandler<int> gameWinnerDidChange;
    public event PropertyChangedHandler<int> teamSizeDidChange;
    public event PropertyChangedHandler<float> roundTotalTimeDidChange;
    public event PropertyChangedHandler<float> roundStartTimeDidChange;
    public event PropertyChangedHandler<float> roundElapsedTimeDidChange;
    public event PropertyChangedHandler<int> team1ScoreDidChange;
    public event PropertyChangedHandler<int> team2ScoreDidChange;
    public event PropertyChangedHandler<int> roundCurrentDidChange;
    public event PropertyChangedHandler<int> roundsPlayedDidChange;
    public event PropertyChangedHandler<int> roundsTotalDidChange;
    public event PropertyChangedHandler<float> team1KillsDidChange;
    public event PropertyChangedHandler<float> team2KillsDidChange;
    public event PropertyChangedHandler<float> team1TotalKillsDidChange;
    public event PropertyChangedHandler<float> team2TotalKillsDidChange;
    public event PropertyChangedHandler<float> team1PlayerCountDidChange;
    public event PropertyChangedHandler<float> team2PlayerCountDidChange;
    
    public enum PropertyID : uint {
        GameMode = 1,
        IsPlayersConnectedAndTeamsAssigned = 2,
        IsPlayersReadyToStartGame = 3,
        IsGameStart = 4,
        IsRoundStarted = 5,
        GameWinner = 6,
        TeamSize = 7,
        RoundTotalTime = 8,
        RoundStartTime = 9,
        RoundElapsedTime = 10,
        Team1Score = 11,
        Team2Score = 12,
        RoundCurrent = 13,
        RoundsPlayed = 14,
        RoundsTotal = 15,
        Team1Kills = 16,
        Team2Kills = 17,
        Team1TotalKills = 18,
        Team2TotalKills = 19,
        Team1PlayerCount = 20,
        Team2PlayerCount = 21,
    }
    
    #region Properties
    
    private UnreliableProperty<int> _gameModeProperty;
    
    private UnreliableProperty<bool> _isPlayersConnectedAndTeamsAssignedProperty;
    
    private UnreliableProperty<bool> _isPlayersReadyToStartGameProperty;
    
    private UnreliableProperty<bool> _isGameStartProperty;
    
    private UnreliableProperty<bool> _isRoundStartedProperty;
    
    private UnreliableProperty<int> _gameWinnerProperty;
    
    private UnreliableProperty<int> _teamSizeProperty;
    
    private UnreliableProperty<float> _roundTotalTimeProperty;
    
    private UnreliableProperty<float> _roundStartTimeProperty;
    
    private UnreliableProperty<float> _roundElapsedTimeProperty;
    
    private UnreliableProperty<int> _team1ScoreProperty;
    
    private UnreliableProperty<int> _team2ScoreProperty;
    
    private UnreliableProperty<int> _roundCurrentProperty;
    
    private UnreliableProperty<int> _roundsPlayedProperty;
    
    private UnreliableProperty<int> _roundsTotalProperty;
    
    private UnreliableProperty<float> _team1KillsProperty;
    
    private UnreliableProperty<float> _team2KillsProperty;
    
    private UnreliableProperty<float> _team1TotalKillsProperty;
    
    private UnreliableProperty<float> _team2TotalKillsProperty;
    
    private UnreliableProperty<float> _team1PlayerCountProperty;
    
    private UnreliableProperty<float> _team2PlayerCountProperty;
    
    #endregion
    
    public GameLogicSyncModel() : base(null) {
        _gameModeProperty = new UnreliableProperty<int>(1, _gameMode);
        _isPlayersConnectedAndTeamsAssignedProperty = new UnreliableProperty<bool>(2, _isPlayersConnectedAndTeamsAssigned);
        _isPlayersReadyToStartGameProperty = new UnreliableProperty<bool>(3, _isPlayersReadyToStartGame);
        _isGameStartProperty = new UnreliableProperty<bool>(4, _isGameStart);
        _isRoundStartedProperty = new UnreliableProperty<bool>(5, _isRoundStarted);
        _gameWinnerProperty = new UnreliableProperty<int>(6, _gameWinner);
        _teamSizeProperty = new UnreliableProperty<int>(7, _teamSize);
        _roundTotalTimeProperty = new UnreliableProperty<float>(8, _roundTotalTime);
        _roundStartTimeProperty = new UnreliableProperty<float>(9, _roundStartTime);
        _roundElapsedTimeProperty = new UnreliableProperty<float>(10, _roundElapsedTime);
        _team1ScoreProperty = new UnreliableProperty<int>(11, _team1Score);
        _team2ScoreProperty = new UnreliableProperty<int>(12, _team2Score);
        _roundCurrentProperty = new UnreliableProperty<int>(13, _roundCurrent);
        _roundsPlayedProperty = new UnreliableProperty<int>(14, _roundsPlayed);
        _roundsTotalProperty = new UnreliableProperty<int>(15, _roundsTotal);
        _team1KillsProperty = new UnreliableProperty<float>(16, _team1Kills);
        _team2KillsProperty = new UnreliableProperty<float>(17, _team2Kills);
        _team1TotalKillsProperty = new UnreliableProperty<float>(18, _team1TotalKills);
        _team2TotalKillsProperty = new UnreliableProperty<float>(19, _team2TotalKills);
        _team1PlayerCountProperty = new UnreliableProperty<float>(20, _team1PlayerCount);
        _team2PlayerCountProperty = new UnreliableProperty<float>(21, _team2PlayerCount);
    }
    
    private void FireGameModeDidChange(int value) {
        try {
            gameModeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireIsPlayersConnectedAndTeamsAssignedDidChange(bool value) {
        try {
            isPlayersConnectedAndTeamsAssignedDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireIsPlayersReadyToStartGameDidChange(bool value) {
        try {
            isPlayersReadyToStartGameDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireIsGameStartDidChange(bool value) {
        try {
            isGameStartDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireIsRoundStartedDidChange(bool value) {
        try {
            isRoundStartedDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireGameWinnerDidChange(int value) {
        try {
            gameWinnerDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeamSizeDidChange(int value) {
        try {
            teamSizeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireRoundTotalTimeDidChange(float value) {
        try {
            roundTotalTimeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireRoundStartTimeDidChange(float value) {
        try {
            roundStartTimeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireRoundElapsedTimeDidChange(float value) {
        try {
            roundElapsedTimeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeam1ScoreDidChange(int value) {
        try {
            team1ScoreDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeam2ScoreDidChange(int value) {
        try {
            team2ScoreDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireRoundCurrentDidChange(int value) {
        try {
            roundCurrentDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireRoundsPlayedDidChange(int value) {
        try {
            roundsPlayedDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireRoundsTotalDidChange(int value) {
        try {
            roundsTotalDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeam1KillsDidChange(float value) {
        try {
            team1KillsDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeam2KillsDidChange(float value) {
        try {
            team2KillsDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeam1TotalKillsDidChange(float value) {
        try {
            team1TotalKillsDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeam2TotalKillsDidChange(float value) {
        try {
            team2TotalKillsDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeam1PlayerCountDidChange(float value) {
        try {
            team1PlayerCountDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireTeam2PlayerCountDidChange(float value) {
        try {
            team2PlayerCountDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _gameModeProperty.WriteLength(context);
        length += _isPlayersConnectedAndTeamsAssignedProperty.WriteLength(context);
        length += _isPlayersReadyToStartGameProperty.WriteLength(context);
        length += _isGameStartProperty.WriteLength(context);
        length += _isRoundStartedProperty.WriteLength(context);
        length += _gameWinnerProperty.WriteLength(context);
        length += _teamSizeProperty.WriteLength(context);
        length += _roundTotalTimeProperty.WriteLength(context);
        length += _roundStartTimeProperty.WriteLength(context);
        length += _roundElapsedTimeProperty.WriteLength(context);
        length += _team1ScoreProperty.WriteLength(context);
        length += _team2ScoreProperty.WriteLength(context);
        length += _roundCurrentProperty.WriteLength(context);
        length += _roundsPlayedProperty.WriteLength(context);
        length += _roundsTotalProperty.WriteLength(context);
        length += _team1KillsProperty.WriteLength(context);
        length += _team2KillsProperty.WriteLength(context);
        length += _team1TotalKillsProperty.WriteLength(context);
        length += _team2TotalKillsProperty.WriteLength(context);
        length += _team1PlayerCountProperty.WriteLength(context);
        length += _team2PlayerCountProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _gameModeProperty.Write(stream, context);
        writes |= _isPlayersConnectedAndTeamsAssignedProperty.Write(stream, context);
        writes |= _isPlayersReadyToStartGameProperty.Write(stream, context);
        writes |= _isGameStartProperty.Write(stream, context);
        writes |= _isRoundStartedProperty.Write(stream, context);
        writes |= _gameWinnerProperty.Write(stream, context);
        writes |= _teamSizeProperty.Write(stream, context);
        writes |= _roundTotalTimeProperty.Write(stream, context);
        writes |= _roundStartTimeProperty.Write(stream, context);
        writes |= _roundElapsedTimeProperty.Write(stream, context);
        writes |= _team1ScoreProperty.Write(stream, context);
        writes |= _team2ScoreProperty.Write(stream, context);
        writes |= _roundCurrentProperty.Write(stream, context);
        writes |= _roundsPlayedProperty.Write(stream, context);
        writes |= _roundsTotalProperty.Write(stream, context);
        writes |= _team1KillsProperty.Write(stream, context);
        writes |= _team2KillsProperty.Write(stream, context);
        writes |= _team1TotalKillsProperty.Write(stream, context);
        writes |= _team2TotalKillsProperty.Write(stream, context);
        writes |= _team1PlayerCountProperty.Write(stream, context);
        writes |= _team2PlayerCountProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.GameMode: {
                    changed = _gameModeProperty.Read(stream, context);
                    if (changed) FireGameModeDidChange(gameMode);
                    break;
                }
                case (uint) PropertyID.IsPlayersConnectedAndTeamsAssigned: {
                    changed = _isPlayersConnectedAndTeamsAssignedProperty.Read(stream, context);
                    if (changed) FireIsPlayersConnectedAndTeamsAssignedDidChange(isPlayersConnectedAndTeamsAssigned);
                    break;
                }
                case (uint) PropertyID.IsPlayersReadyToStartGame: {
                    changed = _isPlayersReadyToStartGameProperty.Read(stream, context);
                    if (changed) FireIsPlayersReadyToStartGameDidChange(isPlayersReadyToStartGame);
                    break;
                }
                case (uint) PropertyID.IsGameStart: {
                    changed = _isGameStartProperty.Read(stream, context);
                    if (changed) FireIsGameStartDidChange(isGameStart);
                    break;
                }
                case (uint) PropertyID.IsRoundStarted: {
                    changed = _isRoundStartedProperty.Read(stream, context);
                    if (changed) FireIsRoundStartedDidChange(isRoundStarted);
                    break;
                }
                case (uint) PropertyID.GameWinner: {
                    changed = _gameWinnerProperty.Read(stream, context);
                    if (changed) FireGameWinnerDidChange(gameWinner);
                    break;
                }
                case (uint) PropertyID.TeamSize: {
                    changed = _teamSizeProperty.Read(stream, context);
                    if (changed) FireTeamSizeDidChange(teamSize);
                    break;
                }
                case (uint) PropertyID.RoundTotalTime: {
                    changed = _roundTotalTimeProperty.Read(stream, context);
                    if (changed) FireRoundTotalTimeDidChange(roundTotalTime);
                    break;
                }
                case (uint) PropertyID.RoundStartTime: {
                    changed = _roundStartTimeProperty.Read(stream, context);
                    if (changed) FireRoundStartTimeDidChange(roundStartTime);
                    break;
                }
                case (uint) PropertyID.RoundElapsedTime: {
                    changed = _roundElapsedTimeProperty.Read(stream, context);
                    if (changed) FireRoundElapsedTimeDidChange(roundElapsedTime);
                    break;
                }
                case (uint) PropertyID.Team1Score: {
                    changed = _team1ScoreProperty.Read(stream, context);
                    if (changed) FireTeam1ScoreDidChange(team1Score);
                    break;
                }
                case (uint) PropertyID.Team2Score: {
                    changed = _team2ScoreProperty.Read(stream, context);
                    if (changed) FireTeam2ScoreDidChange(team2Score);
                    break;
                }
                case (uint) PropertyID.RoundCurrent: {
                    changed = _roundCurrentProperty.Read(stream, context);
                    if (changed) FireRoundCurrentDidChange(roundCurrent);
                    break;
                }
                case (uint) PropertyID.RoundsPlayed: {
                    changed = _roundsPlayedProperty.Read(stream, context);
                    if (changed) FireRoundsPlayedDidChange(roundsPlayed);
                    break;
                }
                case (uint) PropertyID.RoundsTotal: {
                    changed = _roundsTotalProperty.Read(stream, context);
                    if (changed) FireRoundsTotalDidChange(roundsTotal);
                    break;
                }
                case (uint) PropertyID.Team1Kills: {
                    changed = _team1KillsProperty.Read(stream, context);
                    if (changed) FireTeam1KillsDidChange(team1Kills);
                    break;
                }
                case (uint) PropertyID.Team2Kills: {
                    changed = _team2KillsProperty.Read(stream, context);
                    if (changed) FireTeam2KillsDidChange(team2Kills);
                    break;
                }
                case (uint) PropertyID.Team1TotalKills: {
                    changed = _team1TotalKillsProperty.Read(stream, context);
                    if (changed) FireTeam1TotalKillsDidChange(team1TotalKills);
                    break;
                }
                case (uint) PropertyID.Team2TotalKills: {
                    changed = _team2TotalKillsProperty.Read(stream, context);
                    if (changed) FireTeam2TotalKillsDidChange(team2TotalKills);
                    break;
                }
                case (uint) PropertyID.Team1PlayerCount: {
                    changed = _team1PlayerCountProperty.Read(stream, context);
                    if (changed) FireTeam1PlayerCountDidChange(team1PlayerCount);
                    break;
                }
                case (uint) PropertyID.Team2PlayerCount: {
                    changed = _team2PlayerCountProperty.Read(stream, context);
                    if (changed) FireTeam2PlayerCountDidChange(team2PlayerCount);
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
        _gameMode = gameMode;
        _isPlayersConnectedAndTeamsAssigned = isPlayersConnectedAndTeamsAssigned;
        _isPlayersReadyToStartGame = isPlayersReadyToStartGame;
        _isGameStart = isGameStart;
        _isRoundStarted = isRoundStarted;
        _gameWinner = gameWinner;
        _teamSize = teamSize;
        _roundTotalTime = roundTotalTime;
        _roundStartTime = roundStartTime;
        _roundElapsedTime = roundElapsedTime;
        _team1Score = team1Score;
        _team2Score = team2Score;
        _roundCurrent = roundCurrent;
        _roundsPlayed = roundsPlayed;
        _roundsTotal = roundsTotal;
        _team1Kills = team1Kills;
        _team2Kills = team2Kills;
        _team1TotalKills = team1TotalKills;
        _team2TotalKills = team2TotalKills;
        _team1PlayerCount = team1PlayerCount;
        _team2PlayerCount = team2PlayerCount;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
