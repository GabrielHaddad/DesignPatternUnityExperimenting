using UnityEngine;

public class CompositeRunner1 : MonoBehaviour {
    [SerializeField] IBCAbility currentAbility = 
        new SequenceComposite(
            new IBCAbility[] {
                new BCRageAbility(),
                new BCHeal(),
                new CDelayedDecorator(
                    new BCRageAbility()
                )
            }
        );

    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

public interface IBCAbility
{
    void Use(GameObject currentGameObject);
}

public class SequenceComposite : IBCAbility
{
    private IBCAbility[] children;

    public SequenceComposite(IBCAbility[] children)
    {
        this.children = children;
    }

    public void Use(GameObject currentGameObject)
    {
        foreach(var child in children)
        {
            child.Use(currentGameObject);
        }
    }
}

public class CDelayedDecorator : IBCAbility
{
    private IBCAbility wrappedAbility;

    public CDelayedDecorator(IBCAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        //TODO some delaying functionality
        wrappedAbility.Use(currentGameObject);
    }
}

public class BCRageAbility : IBCAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

public class BCFireBall : IBCAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}

public class BCHeal : IBCAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}