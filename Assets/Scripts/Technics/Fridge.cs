public class Fridge : Technics
{
    public MarketMenu marketMenu;

    public override void interact(GameItem pickedObject)
    {
        MainUiFrame.instance.focusOn(marketMenu);
        base.interact(pickedObject);
    }
}