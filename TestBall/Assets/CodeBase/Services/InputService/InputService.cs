namespace CodeBase.Services.InputService
{
    public class InputService : IInputService
    {
        public float Axis => inputService.Axis;

        public IInputService inputService;

        public InputService()
        {
            inputService = new UnityInputService();
        }
    }
}