using SharedKernel.Main.ACL.Domain.Entities;

namespace SharedKernel.Main.ACL.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IStateRepository
    {
        /// <inheritdoc/>
        List<State>? All();
        /// <inheritdoc/>
        State? Find(ulong id);
        /// <inheritdoc/>
        State? Add(State state);
        /// <inheritdoc/>
        State? Update(State state);
        /// <inheritdoc/>
        State? Delete(State state);
        /// <inheritdoc/>
        State? Delete(ulong id);


    }
}
