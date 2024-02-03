namespace AriozoneGames.Narrative
{
    public class EnvironmentNode: NarrativeNode
    {
        public override void StartChain()
        {
            Link.LinkEvent?.Invoke();
            RunChainedEvents();
        }
    }
}