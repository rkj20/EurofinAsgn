using ClubHouseUtil.Model.Dtos;
using System.Collections.Generic;

namespace ClubHouseUtil.Model.Interfaces
{
    public interface IFacilityLocking
    {
        IResposnse CreateLocking(LockingDetails locking);
        List<LockingDetails> ReadAllLocking();
        LockingDetails ReadLocking(string lockingId);
        IResposnse UpdateLocking(LockingDetails locking);
        IResposnse DeleteLocking(LockingDetails locking);
    }
}