using UnityEngine;

public interface IAbilityHolder
{
}

public class ShotGun : IAbilityHolder
{
    public int BulletNumber = 1;
    public float DamagePercent = 100f;
    public GameObject BulletPrefab;
    public void Shot()
    {
        for (int i = 0;i < BulletNumber; i++)
        {
            var bullet = GameObject.Instantiate(BulletPrefab);
            // bullet.Damage = bullet.Damage * (DamagePercent / 100f);
        }
    }
}

public class Pistol : IAbilityHolder
{
    public GameObject BulletPrefab;
    public void Shot()
    {
        GameObject.Instantiate(BulletPrefab);
    }
}

[CreateAssetMenu]
public abstract class BaseAbility : ScriptableObject
{
    public virtual void Attach(IAbilityHolder holder)
    {
    }
}


/// <summary>
/// Tang 1 vien dan cho shotgun
/// </summary>
[CreateAssetMenu]
public class ShotGunAbility_1 : BaseAbility
{
    public override void Attach(IAbilityHolder holder)
    {
        base.Attach(holder);
        if (holder is ShotGun shotGun)
        {
            shotGun.BulletNumber += 1;
        }
    }
}

/// <summary>
/// Giam 50% damage vien dan
/// </summary>
[CreateAssetMenu]
public class ShotGunAbility_2 : BaseAbility
{
    public override void Attach(IAbilityHolder holder)
    {
        base.Attach(holder);
        if (holder is ShotGun shotGun)
        {
            shotGun.DamagePercent *= 0.5f;
        }
    }
}   

public class Game
{
    public void AttachAbility(BaseAbility ability, IAbilityHolder holder)
    {
        ability.Attach(holder);
    }

    public void Demo()
    {
        ShotGun shotGun = new ShotGun();
        shotGun.Shot();

        /////----
       //apply ability shotgun1
       var ability = ScriptableObject.CreateInstance<ShotGunAbility_1>();
        AttachAbility(ability, shotGun);
    }
}