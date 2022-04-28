using MarchingCubes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRTerrainModifier : MonoBehaviour
{
    public AudioSource digNoise;
    [Tooltip("Force of modifications applied to the terrain")]
    public float modiferStrengh = 10;
    [Tooltip("Size of the brush, number of vertex modified")]
    public float sizeHit = 6;
    [Tooltip("Color of the new voxels generated")]
    [Range(0, Constants.NUMBER_MATERIALS - 1)]
    public int buildingMaterial = 0;

    private ChunkManager chunkManager;
    private Vector3 startPos = Vector3.zero;

    void Start()
    {
        chunkManager = ChunkManager.Instance;
        digNoise = GetComponent<AudioSource>();
        startPos = GameObject.Find("StartPosition").transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;

        // Chunk_1|-1 position = 8, -8
        var contacts = collision.contacts;
        float distance = Mathf.Abs((startPos - contacts[0].point).magnitude);
        if (distance <= 4f) return;

        chunkManager.ModifyChunkData(contacts[0].point, sizeHit, -modiferStrengh, buildingMaterial);
        if (!digNoise.isPlaying) digNoise.Play();
    }
}