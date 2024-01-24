using StarterAssets;

namespace AriozoneGames.Narrative
{
    public class UtilityNode: NarrativeNode
    {
        private FirstPersonController _playerController;
        
        new void Start()
        {
            base.Start();
            _playerController = FindObjectOfType<FirstPersonController>();
        }
        
        public override void StartChain()
        {
            Link.LinkEvent?.Invoke();
            RunChainedEvents();
        }

        public void LockPlayerMovement()
        {
            _playerController.enabled = false;
        }

        public void UnlockPlayerMovement()
        {
            _playerController.enabled = true;
        }
    }
}