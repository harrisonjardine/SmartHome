using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FYP_SmartHomeWCF.Models;
using System.Web.Script.Serialization;
using FYP_SmartHomeWCF.Converters;
using System.Data.Entity.Core.Objects;
using System.Transactions;

namespace FYP_SmartHomeWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        db_hj13aajEntities db = new db_hj13aajEntities();
        IConverters ic = new IConverters();

        public string GetUser(Guid userGUID)
        {
            var result = db.tblUsers.FirstOrDefault(x => x.UserGUID == userGUID);
            var user = ic.ConvertToUserModel(result);
            var json = new JavaScriptSerializer().Serialize(user);
            return json;
        }

        public string GetUserHomes(Guid userGUID)
        {
            var result = db.tblHouseOwners.Where(x => x.UserGUID == userGUID);
            var userHomes = ic.ConvertToUserHomesModel(result, userGUID);
            var json = new JavaScriptSerializer().Serialize(userHomes);
            return json;
        }

        public string GetUserRooms(Guid userGUID)
        {
            var result = db.tblRoomOwners.Where(x => x.UserGUID == userGUID);
            var userHomes = ic.ConvertToUserRoomsModel(result, userGUID);
            var json = new JavaScriptSerializer().Serialize(userHomes);
            return json;
        }


        public string GetHomeRoomsWithUser(Guid homeGUID, Guid userGUID)
        {
            var result = db.tblRooms.Where(x => x.HouseGUID == homeGUID);
            var userHomes = ic.ConvertToHomeRoomsWithUserModel(result, homeGUID, userGUID);
            var json = new JavaScriptSerializer().Serialize(userHomes);
            return json;
        }

        //If user doesn't have Admin Access to home, return empty home
        public string GetHomeRoomsAdmin(Guid homeGUID, Guid userGUID)
        {
            bool permission = db.tblHouseOwners.Any(x => x.HouseGUID == homeGUID && x.UserGUID == userGUID);
            if (permission)
            {
                var result = db.tblRooms.Where(x => x.HouseGUID == homeGUID);
                var home = db.tblHouses.FirstOrDefault(x => x.HouseGUID == homeGUID);
                var userHomes = ic.ConvertToHomeModel(result, home);
                var json = new JavaScriptSerializer().Serialize(userHomes);
                return json;
            }
            else
            {
                HouseRooms hr = new HouseRooms();
                hr.house = new House();
                hr.rooms = new List<Room>();
                var json = new JavaScriptSerializer().Serialize(hr);
                return json;
            }
        }

        public string GetHouseObjects(Guid houseGUID)
        {
            var objects = db.tblRoomObjects.Where(x => x.HouseGUID == houseGUID);
            HouseObjects ho = new HouseObjects();
            ho.houseGUID = houseGUID;
            ho.objects = ic.ConvertToObjectModel(objects);
            var json = new JavaScriptSerializer().Serialize(ho);
            return json;
        }

        public string GetRoomObjects(Guid roomGUID)
        {
            var objects = db.tblRoomObjects.Where(x => x.RoomGUID == roomGUID);
            RoomObjects ro = new RoomObjects();
            ro.roomGuid = roomGUID;
            ro.objects = ic.ConvertToObjectModel(objects);
            var json = new JavaScriptSerializer().Serialize(ro);
            return json;
        }

        public string GetUsers()
        {
            var users = db.tblUsers.OrderBy(x => x.UserName);
            List<User> userList = new List<User>();
            foreach (var user in users)
            {
                userList.Add(ic.ConvertToUserModel(user));
            }
            var json = new JavaScriptSerializer().Serialize(userList);
            return json;
        }

        private Models.Object GetObject(Guid objectGuid)
        {
            var getObject = db.tblRoomObjects.FirstOrDefault(x => x.ObjectGUID == objectGuid);
            
            var newObject = ic.ConvertEachObjectModel(getObject);
            
            return newObject;
        }

        public string AddHouseAndOwner(Guid owner, string HouseName)
        {
            Guid HouseGuid = Guid.NewGuid();
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            HouseOwner houseOwner = new HouseOwner();
            House house = new House();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_AddHouse(HouseGuid.ToString(), HouseName, Output);
                if (Output.Value.ToString() == "Success")
                {
                    db.usp_AddOwnerToHouse(owner.ToString(), HouseGuid.ToString(), Output);
                    if (Output.Value.ToString() == "Success")
                    {
                        scope.Complete();
                        house.HouseGuid = HouseGuid;
                        house.HouseName = HouseName;
                        houseOwner.house = house;
                        houseOwner.ownerGuid = owner;
                    }
                    else
                    {
                        house.HouseGuid = Guid.Empty;
                        house.HouseName = Output.Value.ToString();
                        houseOwner.house = house;
                        houseOwner.ownerGuid = Guid.Empty;
                        scope.Dispose();
                    }

                }
                else
                {
                    house.HouseGuid = Guid.Empty;
                    house.HouseName = Output.Value.ToString();
                }
            }
            var json = new JavaScriptSerializer().Serialize(houseOwner);
            return json;
        }

        public string AddUser(string userName, string firstName, string lastName, string emailAddress, string userPassword)
        {
            Guid UserGuid = Guid.NewGuid();
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            User user = new User();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_AddUser(UserGuid.ToString(), userName, userPassword, firstName, lastName, emailAddress, Output);

                if (Output.Value.ToString() == "Success")
                {
                    scope.Complete();
                    user.UserGuid = UserGuid;
                    user.UserName = userName;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.EmailAddress = emailAddress;
                    user.EmailVerified = false;
                }
                else
                {
                    user.UserGuid = Guid.Empty;
                    user.UserName = Output.Value.ToString();
                    user.FirstName = null;
                    user.LastName = null;
                    user.EmailAddress = null;
                    user.EmailVerified = false;
                    scope.Dispose();
                }
            }
            var json = new JavaScriptSerializer().Serialize(user);
            return json;
        }

        public string AddRoom(Guid houseGuid, string roomName)
        {
            Guid RoomGuid = Guid.NewGuid();
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            Room room = new Room();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_AddRoom(RoomGuid.ToString(), houseGuid.ToString(), roomName, Output);

                if (Output.Value.ToString() == "Success")
                {
                    scope.Complete();
                    room.HouseGuid = houseGuid;
                    room.RoomGuid = RoomGuid;
                    room.RoomName = roomName;
                }
                else
                {
                    room.HouseGuid = Guid.Empty;
                    room.RoomGuid = Guid.Empty;
                    room.RoomName = Output.Value.ToString();
                    scope.Dispose();
                }
            }
            var json = new JavaScriptSerializer().Serialize(room);
            return json;
        }

        public string AddRoomOwner(Guid roomGuid, Guid userGuid)
        {
            Guid RoomGuid = Guid.NewGuid();
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            RoomOwner roomOwner = new RoomOwner();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_AddOwnerToRoom(userGuid.ToString(), RoomGuid.ToString(), Output);

                if (Output.Value.ToString() == "Success")
                {
                    scope.Complete();
                    roomOwner.room = roomGuid;
                    roomOwner.user = userGuid;
                }
                else
                {
                    roomOwner.room = Guid.Empty;
                    roomOwner.user = Guid.Empty;
                    roomOwner.desc = Output.Value.ToString();
                    scope.Dispose();
                }
            }
            var json = new JavaScriptSerializer().Serialize(roomOwner);
            return json;
        }

        public string AddObject(Guid houseGuid, string objectDescription, string objectState)
        {
            Guid ObjectGuid = Guid.NewGuid();
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            var newObject = new Models.Object();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_AddObject(ObjectGuid.ToString(),houseGuid.ToString(), objectDescription, objectState, Output);

                newObject = ObjectOutput(Output, ObjectGuid);
                if (Output.Value.ToString() == "Success")
                    scope.Complete();
                else
                    scope.Dispose();
            }
            var json = new JavaScriptSerializer().Serialize(newObject);
            return json;
        }

        public string AddObjectRoom(Guid objectGuid, Guid roomGuid, string objectDescription)
        {
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            var newObject = new Models.Object();
            using (TransactionScope scope = new TransactionScope())
            {
                if (String.IsNullOrEmpty(objectDescription))
                    objectDescription = db.tblRoomObjects.FirstOrDefault(x => x.ObjectGUID == objectGuid).ObjectDescription;
                db.usp_AddObjectToRoom(objectGuid.ToString(), roomGuid.ToString(), objectDescription, Output);

                newObject = ObjectOutput(Output, objectGuid);
                if (Output.Value.ToString() == "Success")
                    scope.Complete();
                else
                    scope.Dispose();
            }
            var json = new JavaScriptSerializer().Serialize(newObject);
            return json;
        }

        public string EditObjectType(Guid objectGuid, Guid objectTypeGuid)
        {
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            var newObject = new Models.Object();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_AddTypeToObject(objectGuid.ToString(), objectTypeGuid.ToString(), Output);

                newObject = ObjectOutput(Output, objectGuid);
                if (Output.Value.ToString() == "Success")
                    scope.Complete();
                else
                    scope.Dispose();
            }
            var json = new JavaScriptSerializer().Serialize(newObject);
            return json;
        }

        public string EditObjectState(Guid objectGuid, string objectState)
        {
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            var newObject = new Models.Object();
            using (TransactionScope scope = new TransactionScope())
            {
                var currentObject = db.tblRoomObjects.FirstOrDefault(x => x.ObjectGUID == objectGuid);
                db.tblRoomObjects.Attach(currentObject);
                currentObject.ObjectState = objectState;
                var entry = db.Entry(currentObject);
                entry.Property(x => x.ObjectState).IsModified = true;
                try
                {
                    db.SaveChanges();
                    Output.Value = "Success";
                }
                catch (Exception ex)
                {
                    Output.Value = ex.Message + "- Inner ex: " + ex.InnerException.Message;
                }
                newObject = ObjectOutput(Output, objectGuid);
                if (Output.Value.ToString() == "Success")
                    scope.Complete();
                else
                    scope.Dispose();
            }
            var json = new JavaScriptSerializer().Serialize(newObject);
            return json;
        }

        public string EditHouse(Guid houseGUID, string HouseName)
        {
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            var editHouse = new House();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_EditHouse(houseGUID.ToString(), HouseName, Output);


                if (Output.Value.ToString() == "Success")
                {
                    scope.Complete();
                    editHouse.HouseGuid = houseGUID;
                    editHouse.HouseName = HouseName;
                }
                else
                {
                    scope.Dispose();
                    editHouse.HouseGuid = Guid.Empty;
                    editHouse.HouseName = Output.Value.ToString();
                }
            }
            var json = new JavaScriptSerializer().Serialize(editHouse);
            return json;
        }

        public string EditRoomDetails(Guid roomGuid, string RoomName)
        {
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            var editRoom = new Room();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_EditRoomDetails(roomGuid.ToString(), RoomName, Output);

                if (Output.Value.ToString() == "Success")
                {
                    scope.Complete();
                    editRoom.RoomGuid = roomGuid;
                    editRoom.RoomName = RoomName;
                }
                else
                {
                    scope.Dispose();
                    editRoom.RoomGuid = Guid.Empty;
                    editRoom.RoomName = Output.Value.ToString();
                }
            }
            var json = new JavaScriptSerializer().Serialize(editRoom);
            return json;
        }

        public string EditUserDetails(Guid userGuid, string userName, string firstName, string lastName, string emailAddress)
        {
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            var editUser = new User();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_EditUserDetails(userGuid.ToString(), userName, firstName, lastName, emailAddress, Output);

                if (Output.Value.ToString() == "Success")
                {
                    scope.Complete();
                    editUser.EmailAddress = emailAddress;
                    editUser.FirstName = firstName;
                    editUser.LastName = lastName;
                    editUser.UserName = userName;
                    editUser.UserGuid = userGuid;
                }
                else
                {
                    scope.Dispose();
                    editUser.UserGuid = Guid.Empty;
                    editUser.UserName = Output.Value.ToString();
                }
            }
            var json = new JavaScriptSerializer().Serialize(editUser);
            return json;
        }

        public string EditUserPassword(Guid userGuid, string userPassword)
        {
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            var editUser = new User();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_EditUserPassword(userGuid.ToString(), userPassword, Output);

                if (Output.Value.ToString() == "Success")
                {
                    scope.Complete();
                    editUser.UserGuid = userGuid;
                }
                else
                {
                    scope.Dispose();
                    editUser.UserGuid = Guid.Empty;
                    editUser.UserName = Output.Value.ToString();
                }
            }
            var json = new JavaScriptSerializer().Serialize(editUser);
            return json;
        }

        public string UserLogin(string userName, string userPassword)
        {
            ObjectParameter Output = new ObjectParameter("responseMessage", typeof(string));
            ObjectParameter OutputGuid = new ObjectParameter("UserGuid", typeof(string));
            var editUser = new User();
            using (TransactionScope scope = new TransactionScope())
            {
                db.usp_UserLogin(userName, userPassword, Output, OutputGuid);

                if (Output.Value.ToString() == "Success")
                {
                    scope.Complete();
                    editUser.UserGuid = Guid.Parse(OutputGuid.Value.ToString());
                    editUser.UserName = Output.Value.ToString();
                }
                else
                {
                    scope.Dispose();
                    editUser.UserGuid = Guid.Empty;
                    editUser.UserName = Output.Value.ToString();
                }
            }
            var json = new JavaScriptSerializer().Serialize(editUser);
            return json;
        }

        private Models.Object ObjectOutput(ObjectParameter Output, Guid objectGuid)
        {
            var newObject = new Models.Object();
            if (Output.Value.ToString() == "Success")
            {
                var obj = GetObject(objectGuid);
                newObject.ObjectGuid = objectGuid;
                newObject.ObjectDescription = obj.ObjectDescription;
                newObject.ObjectState = obj.ObjectState;
                newObject.HouseGuid = obj.HouseGuid;
                newObject.ObjectType = obj.ObjectType;
                newObject.ObjectTypeGuid = obj.ObjectTypeGuid;
                newObject.RoomGuid = obj.RoomGuid;
            }
            else
            {
                newObject.ObjectGuid = Guid.Empty;
                newObject.ObjectDescription = Output.Value.ToString();
                newObject.ObjectState = null;
                newObject.HouseGuid = Guid.Empty;
                newObject.ObjectType = null;
                newObject.ObjectTypeGuid = Guid.Empty;
                newObject.RoomGuid = Guid.Empty;
            }
            return newObject;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
