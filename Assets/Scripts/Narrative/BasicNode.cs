namespace AriozoneGames.Narrative
{
    public class BasicNode: NarrativeNode
    {
        public override void StartChain()
        {
            Link.LinkEvent?.Invoke();
            RunChainedEvents();
        }
    }
}