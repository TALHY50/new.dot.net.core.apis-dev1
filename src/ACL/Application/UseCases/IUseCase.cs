namespace ACL.Application.UseCases
{
    /// <inheritdoc/>
    public interface IUseCase<R, S>
        where R : Request
        where S : Response
    {
        /// <inheritdoc/>
        public Task<S> Execute(R request);
    }
}
