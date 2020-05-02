namespace ClubHouseUtil.Model.Interfaces
{
    using ClubHouseUtil.Model.Dtos;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for Facility Access
    /// </summary>
    public interface IFacilityAccess
    {
        /// <summary>
        /// Create Access to Facility
        /// </summary>
        /// <param name="Access"></param>
        /// <returns></returns>
        IResposnse CreateAccess(AccessDetails Access);

        /// <summary>
        /// Read all Access for the Facility
        /// </summary>
        /// <returns></returns>
        List<AccessDetails> ReadAllAccess();

        /// <summary>
        /// Read specific Access for the Facility
        /// </summary>
        /// <param name="AccessId"></param>
        /// <returns></returns>
        AccessDetails ReadAccess(int AccessId);

        /// <summary>
        /// Update specific Access to Facility
        /// </summary>
        /// <param name="Access"></param>
        /// <returns></returns>
        IResposnse UpdateAccess(AccessDetails Access);

        /// <summary>
        /// Delete Specific Access from Facility
        /// </summary>
        /// <param name="Access"></param>
        /// <returns></returns>
        IResposnse DeleteAccess(AccessDetails Access);
    }
}