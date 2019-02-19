using System;

public interface ITimer {
    
    float CurrentTime { get; }
    bool IsActive { get; }
    
    event EventHandler OnTimerElapse;
    
    void Initialize();
    void Stop();
    
    float StartTime { get; }    
}
