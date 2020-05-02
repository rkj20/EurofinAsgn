namespace ClubHouseUtil.Model.Interfaces
{
    /// <summary>
    /// Interface for Response messages
    /// </summary>
    public interface IResposnse
    {
        /// <summary>
        /// Gets the response message.
        /// </summary>
        /// <value>
        /// The response message.
        /// </value>
        string ResponseMessage { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IResposnse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        bool Success { get; }
    }
}