using ClubHouseUtil.Model.Dtos;
using System.Collections.Generic;

namespace ClubHouseUtil.Model.Interfaces
{
    public interface IFacilityMaintenance
    {
        IResposnse CreateMaintenance(MaintenanceDetails maintenance);
        List<MaintenanceDetails> ReadAllMaintenance();
        MaintenanceDetails ReadMaintenance(string maintenanceId);
        IResposnse UpdateMaintenance(MaintenanceDetails maintenance);
        IResposnse DeleteMaintenance(MaintenanceDetails maintenance);
    }
}