using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private int _additionalScale;
    [SerializeField] private Beam _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;
    private float _startAndFinishAdditionalScale = 0.5f;

    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;
    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        var beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1f, BeamScaleY, 1f);

        var spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform.parent);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, beam.transform.parent);
        }
        
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform.parent);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1f;
    }
}
