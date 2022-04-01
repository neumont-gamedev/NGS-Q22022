using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoStoneLayerHandler : BlockLayerHandler
{
    [Range(0, 1)]
    public float dinoThreshold = 0.5f;

    [SerializeField]
    private NoiseSettings dinoNoiseSettings;

    public DomainWarping domainWarping;

    protected override bool TryHandling(ChunkData chunkData, int x, int y, int z, int surfaceHeightNoise, Vector2Int mapSeedOffset)
    {
        if (chunkData.worldPosition.y > surfaceHeightNoise)
            return false;

        dinoNoiseSettings.worldOffset = mapSeedOffset;
        // float stoneNoise = MyNoise.OctavePerlin(chunkData.worldPosition.x + x, chunkData.worldPosition.z + z, stoneNoiseSettings);

        float dinoNoise = domainWarping.GenerateDomainNoise(chunkData.worldPosition.x + x, chunkData.worldPosition.z + z, dinoNoiseSettings);

        int endPosition = surfaceHeightNoise;
        if (chunkData.worldPosition.y < 0)
        {
            endPosition = chunkData.worldPosition.y + chunkData.chunkHeight;
        }

        if (dinoNoise > dinoThreshold)
        {
            for (int i = chunkData.worldPosition.y; i <= endPosition; i++)
            {
                Vector3Int pos = new Vector3Int(x, i, z);
                Chunk.SetBlock(chunkData, pos, BlockType.DinoStone, "Dinostone");
            }
            return true;
        }
        return false;
    }
}
