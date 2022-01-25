using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellSpawner : MonoBehaviour
{
    public int numberOfColumns;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifeTime;
    public float fireRate;
    public float size;
    float angle;
    public float spin_speed;
    float time;
    public Material material;

    public ParticleSystem system;

    [SerializeField]
    Transform player;

    EffectBulletTrigger effectBulletTrigger;

    void Awake()
    {
        Summon();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CancelInvoke("DoEmit");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            InvokeRepeating("DoEmit", 0, fireRate);
        }
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time * spin_speed);
    }

    void Summon()
    {
        angle = 360f / numberOfColumns;
        for (int i = 0; i < numberOfColumns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = transform;
            go.transform.position = transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 100000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var emission = system.emission;
            emission.enabled = false;

            var forma = system.shape;
            forma.enabled = true;
            forma.shapeType = ParticleSystemShapeType.Sprite;
            forma.sprite = null;

            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);

            var trigger = system.trigger;
            trigger.enabled = true;
            trigger.AddCollider(player);
            trigger.enter = ParticleSystemOverlapAction.Callback;
            trigger.colliderQueryMode = ParticleSystemColliderQueryMode.All;

            var renderer = system.gameObject.GetComponent<ParticleSystemRenderer>();
            renderer.sortingLayerID = unchecked((int)2578643935);
            renderer.sortingOrder = -1;
            renderer.enabled = true;

            system.gameObject.AddComponent(typeof(EffectBulletTrigger));
        }
        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0, fireRate);
    }

    void DoEmit()
    {
        foreach (Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifeTime;
            system.Emit(emitParams, 10);
            system.Play(); // Continue normal emissions
        }
    }

    private void OnParticleTrigger()
    {
        Debug.Log("trigger");
    }
}
