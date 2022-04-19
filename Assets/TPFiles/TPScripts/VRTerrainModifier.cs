using MarchingCubes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRTerrainModifier : MonoBehaviour
{
    public Text textSize;
    public Text textMaterial;
    public AudioSource digNoise;
    [Tooltip("Force of modifications applied to the terrain")]
    public float modiferStrengh = 10;
    [Tooltip("Size of the brush, number of vertex modified")]
    public float sizeHit = 6;
    [Tooltip("Color of the new voxels generated")]
    [Range(0, Constants.NUMBER_MATERIALS - 1)]
    public int buildingMaterial = 0;

    public int startingChunkX = 1;
    public int startingChunkZ = -1;
    public float chunkSize = 8f;

    private string startingChunk = "Chunk_1|-1";
    private ChunkManager chunkManager;
    private Vector3 startPos = Vector3.zero;

    void Start()
    {
        chunkManager = ChunkManager.Instance;
        digNoise = GetComponent<AudioSource>();
        startingChunk = $"Chunk_{startingChunkX}|{startingChunkZ}";
        startPos = GameObject.Find("StartPosition").transform.position;
        UpdateUI();
    }

    public void UpdateUI()
    {
        textSize.text = "(+ -) Brush size: " + sizeHit;
        textMaterial.text = "(Mouse wheel) Actual material: " + buildingMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;

        Debug.LogWarning($"Y: {collision.contacts[0].point.y}");
        Debug.LogWarning($"Chunk Hit: {collision.gameObject.name}");
        Debug.LogWarning($"Starting Chunk: {startingChunk}");

        // Chunk_1|-1 position = 8, -8
        float x = Mathf.Abs(collision.contacts[0].point.x - (startingChunkX * chunkSize));
        float z = Mathf.Abs(collision.contacts[0].point.z - (startingChunkZ * chunkSize));
        float distance = Mathf.Abs((startPos - collision.contacts[0].point).magnitude);

        //if (x <= 4f && z <= 4f) return;
        if (distance <= 4f) return;

        float modification = -modiferStrengh;
        var contacts = collision.contacts;
        chunkManager.ModifyChunkData(contacts[0].point, sizeHit, modification, buildingMaterial);
        if (!digNoise.isPlaying) digNoise.Play();
    }
}
