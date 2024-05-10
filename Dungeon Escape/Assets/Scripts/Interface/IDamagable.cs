public interface IDamagable
{
    public int health { get; set; }

    public abstract void Damage(int damage);
}
