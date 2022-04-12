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

    private ChunkManager chunkManager;

    void Start()
    {
        chunkManager = ChunkManager.Instance;
        digNoise = GetComponent<AudioSource>();
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

        float modification = -modiferStrengh;
        var contacts = collision.contacts;
        chunkManager.ModifyChunkData(contacts[0].point, sizeHit, modification, buildingMaterial);
        if (!digNoise.isPlaying) digNoise.Play();
    }
}
