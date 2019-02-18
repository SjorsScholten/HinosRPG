using System;
using UnityEngine;

public interface IInput {
    event EventHandler Interacting;
    Vector3 MovementDirection { get; }
    bool IsRunning { get; }
}
