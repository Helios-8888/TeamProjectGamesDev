namespace InteractableItems
{
    public interface IInteractable
    {
        public string InteractableMessage { get; }
        public string interactableName { get; }
        public void Interact();
    }
}