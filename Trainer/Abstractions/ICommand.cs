namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface ICommand<TCommand>
    {
        void Execute(TCommand command);
    }
}
