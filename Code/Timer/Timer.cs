public class Timer 
{
    private float currentTimePassed;
    private float triggerTime;
    private bool isLocked;   


    public float RecordTime(float deltaTime)
    {
        return currentTimePassed += deltaTime;
    }

    public float GetElapedTime()
    {
        return currentTimePassed;
    }

    public void SetTimer(float waitTime)
    {
        triggerTime = waitTime;
        currentTimePassed = 0;
    }

    public void SetLock(bool isLocked)
    {
        this.isLocked = isLocked;
    }

    public bool IsLocked()
    {
        return isLocked;
    }

    public bool IsDone()
    {
        var hasTriggerd = false;
        if( currentTimePassed > triggerTime )
        {
            return hasTriggerd = true;
        }
        return hasTriggerd;
    }
}


/* Use example

if(!spawnTimer.IsLocked())
{
    spawnTimer.SetLock(true);
    spawnTimer.SetTimer(10f);
}

if(spawnTimer.IsLocked())
{
    spawnTimer.RecordTime(Time.deltaTime);
}

if(spawnTimer.IsDone())
{
    spawnTimer.SetLock(false);
    Spawn(1);
}

            */