using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaveSpawner
{
    void SpawnWave();
}
public class DontSpawn : IWaveSpawner
{
    public void SpawnWave()
    {

    }
}

public static class WaveSpawner
{
    private static IWaveSpawner currentInstance;

    public static IWaveSpawner CurrentInstance
    {
        get
        {
            if (currentInstance == null)
                return new DontSpawn();

            return currentInstance;
        }
        internal set
        {
            currentInstance = value;
        }
    }

}
