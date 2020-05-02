namespace ClubHouseUtil.Model.Dtos
{
    using ClubHouseUtil.Model.Interfaces;

    /// <summary>
    /// Response message for the request
    /// </summary>
    /// <seealso cref="IResposnse" />
    public class Resposnse : IResposnse
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="Resposnse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; }

        /// <summary>
        /// Gets the response message.
        /// </summary>
        /// <value>
        /// The response message.
        /// </value>
        public string ResponseMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resposnse"/> class.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="msg">The MSG.</param>
        public Resposnse(bool success, string msg)
        {
            Success = success;
            ResponseMessage = msg;
        }
    }
}
