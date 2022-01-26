using UnityEngine;
using System.Collections.Generic;

class PlayerData{
    public Vector2 position;
    public int health;
    public int maxHealth;
    public int coin;
    public int maxArmor;
    public int currentGun;
    public List<Gun> availableGun = new List<Gun>();
    public int savePoint;
    public int level = 1;

    public PlayerData(Vector2 position, PlayerController data, int savePoint, int level){
        this.position = position;
        this.health = data.CurrentHealth;
        this.maxHealth = data.MaxHealth;
        this.coin = data.Coin;
        this.currentGun = data.CurrentGun;
        this.maxArmor = data.MaxArmor;
        this.availableGun = data.availableGun;
        this.savePoint = savePoint;
        this.level = level;
    }

}