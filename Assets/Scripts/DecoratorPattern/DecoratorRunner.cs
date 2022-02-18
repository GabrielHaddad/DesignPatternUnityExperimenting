using UnityEngine;

public class DecoratorRunner1 : MonoBehaviour {
    [SerializeField] IBAbility currentAbility = new DelayedDecorator(new BRageAbility());

    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

public interface IBAbility
{
    void Use(GameObject currentGameObject);
}

public class DelayedDecorator : IBAbility
{
    private IBAbility wrappedAbility;

    public DelayedDecorator(IBAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        //TODO some delaying functionality
        wrappedAbility.Use(currentGameObject);
    }
}

public class BRageAbility : IBAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

public class BFireBall : IBAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}

public class BHeal : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}