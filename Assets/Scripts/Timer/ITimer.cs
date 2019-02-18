using System;

public interface ITimer {
    event EventHandler OnTimerElapse;
    void Start();
    void Pause();
}
