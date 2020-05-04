public class Fridge : Technics
{
    public MarketMenu marketMenu;

    public override void Start()
    {
        base.Start();
        marketMenu.menuState += switchState;
    }

    public override void interact(GameItem pickedObject)
    {
        MainUiFrame.instance.focusOn(marketMenu);
    }

    private void switchState(bool state)
    {
        isOpen = !state;
        playAnimation();
    }
}