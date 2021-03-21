namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface IQuery<TResult>
    {
        TResult Execute();
    }

    public interface IQuery<TResult, TQuery>
    {
        TResult Execute(TQuery query);
    }
}
