using FYP_SmartHomeWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FYP_SmartHomeWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetUser(Guid userGUID);

        [OperationContract]
        string GetUserHomes(Guid userGUID);

        [OperationContract]
        string GetUserRooms(Guid homeGUID);

        [OperationContract]
        string GetHomeRoomsWithUser(Guid homeGUID, Guid userGUID);

        [OperationContract]
        string GetHomeRoomsAdmin(Guid homeGUID, Guid userGUID);

        [OperationContract]
        string GetHouseObjects(Guid houseGUID);

        [OperationContract]
        string GetRoomObjects(Guid roomGUID);

        [OperationContract]
        string GetUsers();

        [OperationContract]
        string AddHouseAndOwner(Guid owner, string HouseName);

        [OperationContract]
        string AddUser(string userName, string firstName, string lastName, string emailAddress, string userPassword);

        [OperationContract]
        string AddRoom(Guid houseGuid, string RoomName);

        [OperationContract]
        string AddRoomOwner(Guid roomGuid, Guid userGuid);

        [OperationContract]
        string AddObject(Guid houseGuid, string objectDescription, string objectState);

        [OperationContract]
        string AddObjectRoom(Guid objectGuid, Guid roomGuid, string objectDescription);

        [OperationContract]
        string EditObjectType(Guid objectGuid, Guid objectTypeGuid);

        [OperationContract]
        string EditHouse(Guid houseGUID, string HouseName);

        [OperationContract]
        string EditRoomDetails(Guid roomGuid, string RoomName);

        [OperationContract]
        string EditObjectState(Guid objectGuid, string objectState);

        [OperationContract]
        string EditUserDetails(Guid userGuid ,string userName, string firstName, string lastName, string emailAddress);

        [OperationContract]
        string EditUserPassword(Guid userGuid, string userPassword);

        [OperationContract]
        string UserLogin(string userName, string userPassword);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
