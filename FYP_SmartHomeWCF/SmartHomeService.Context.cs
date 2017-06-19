﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FYP_SmartHomeWCF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class db_hj13aajEntities : DbContext
    {
        public db_hj13aajEntities()
            : base("name=db_hj13aajEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblHouse> tblHouses { get; set; }
        public virtual DbSet<tblHouseOwner> tblHouseOwners { get; set; }
        public virtual DbSet<tblObjectType> tblObjectTypes { get; set; }
        public virtual DbSet<tblRoomObject> tblRoomObjects { get; set; }
        public virtual DbSet<tblRoomOwner> tblRoomOwners { get; set; }
        public virtual DbSet<tblRoom> tblRooms { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    
        public virtual int usp_AddHouse(string houseGUID, string houseName, ObjectParameter responseMessage)
        {
            var houseGUIDParameter = houseGUID != null ?
                new ObjectParameter("HouseGUID", houseGUID) :
                new ObjectParameter("HouseGUID", typeof(string));
    
            var houseNameParameter = houseName != null ?
                new ObjectParameter("HouseName", houseName) :
                new ObjectParameter("HouseName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddHouse", houseGUIDParameter, houseNameParameter, responseMessage);
        }
    
        public virtual int usp_AddObject(string objectGUID, string houseGUID, string objectDescription, string objectState, ObjectParameter responseMessage)
        {
            var objectGUIDParameter = objectGUID != null ?
                new ObjectParameter("ObjectGUID", objectGUID) :
                new ObjectParameter("ObjectGUID", typeof(string));
    
            var houseGUIDParameter = houseGUID != null ?
                new ObjectParameter("HouseGUID", houseGUID) :
                new ObjectParameter("HouseGUID", typeof(string));
    
            var objectDescriptionParameter = objectDescription != null ?
                new ObjectParameter("ObjectDescription", objectDescription) :
                new ObjectParameter("ObjectDescription", typeof(string));
    
            var objectStateParameter = objectState != null ?
                new ObjectParameter("ObjectState", objectState) :
                new ObjectParameter("ObjectState", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddObject", objectGUIDParameter, houseGUIDParameter, objectDescriptionParameter, objectStateParameter, responseMessage);
        }
    
        public virtual int usp_AddObjectToRoom(string objectGUID, string roomGUID, string objectDescription, ObjectParameter responseMessage)
        {
            var objectGUIDParameter = objectGUID != null ?
                new ObjectParameter("ObjectGUID", objectGUID) :
                new ObjectParameter("ObjectGUID", typeof(string));
    
            var roomGUIDParameter = roomGUID != null ?
                new ObjectParameter("RoomGUID", roomGUID) :
                new ObjectParameter("RoomGUID", typeof(string));
    
            var objectDescriptionParameter = objectDescription != null ?
                new ObjectParameter("ObjectDescription", objectDescription) :
                new ObjectParameter("ObjectDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddObjectToRoom", objectGUIDParameter, roomGUIDParameter, objectDescriptionParameter, responseMessage);
        }
    
        public virtual int usp_AddObjectType(string objectTypeGUID, string objectName, ObjectParameter responseMessage)
        {
            var objectTypeGUIDParameter = objectTypeGUID != null ?
                new ObjectParameter("ObjectTypeGUID", objectTypeGUID) :
                new ObjectParameter("ObjectTypeGUID", typeof(string));
    
            var objectNameParameter = objectName != null ?
                new ObjectParameter("ObjectName", objectName) :
                new ObjectParameter("ObjectName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddObjectType", objectTypeGUIDParameter, objectNameParameter, responseMessage);
        }
    
        public virtual int usp_AddOwnerToHouse(string userGUID, string houseGUID, ObjectParameter responseMessage)
        {
            var userGUIDParameter = userGUID != null ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(string));
    
            var houseGUIDParameter = houseGUID != null ?
                new ObjectParameter("HouseGUID", houseGUID) :
                new ObjectParameter("HouseGUID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddOwnerToHouse", userGUIDParameter, houseGUIDParameter, responseMessage);
        }
    
        public virtual int usp_AddOwnerToRoom(string userGUID, string roomGUID, ObjectParameter responseMessage)
        {
            var userGUIDParameter = userGUID != null ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(string));
    
            var roomGUIDParameter = roomGUID != null ?
                new ObjectParameter("RoomGUID", roomGUID) :
                new ObjectParameter("RoomGUID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddOwnerToRoom", userGUIDParameter, roomGUIDParameter, responseMessage);
        }
    
        public virtual int usp_AddRoom(string roomGUID, string houseGUID, string roomName, ObjectParameter responseMessage)
        {
            var roomGUIDParameter = roomGUID != null ?
                new ObjectParameter("RoomGUID", roomGUID) :
                new ObjectParameter("RoomGUID", typeof(string));
    
            var houseGUIDParameter = houseGUID != null ?
                new ObjectParameter("HouseGUID", houseGUID) :
                new ObjectParameter("HouseGUID", typeof(string));
    
            var roomNameParameter = roomName != null ?
                new ObjectParameter("RoomName", roomName) :
                new ObjectParameter("RoomName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddRoom", roomGUIDParameter, houseGUIDParameter, roomNameParameter, responseMessage);
        }
    
        public virtual int usp_AddUser(string userGUID, string userName, string userPassword, string firstName, string lastName, string emailAddress, ObjectParameter responseMessage)
        {
            var userGUIDParameter = userGUID != null ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userPasswordParameter = userPassword != null ?
                new ObjectParameter("UserPassword", userPassword) :
                new ObjectParameter("UserPassword", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddUser", userGUIDParameter, userNameParameter, userPasswordParameter, firstNameParameter, lastNameParameter, emailAddressParameter, responseMessage);
        }
    
        public virtual int usp_EditHouse(string houseGUID, string houseName, ObjectParameter responseMessage)
        {
            var houseGUIDParameter = houseGUID != null ?
                new ObjectParameter("HouseGUID", houseGUID) :
                new ObjectParameter("HouseGUID", typeof(string));
    
            var houseNameParameter = houseName != null ?
                new ObjectParameter("HouseName", houseName) :
                new ObjectParameter("HouseName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_EditHouse", houseGUIDParameter, houseNameParameter, responseMessage);
        }
    
        public virtual int usp_EditObjectType(string objectTypeGUID, string objectName, ObjectParameter responseMessage)
        {
            var objectTypeGUIDParameter = objectTypeGUID != null ?
                new ObjectParameter("ObjectTypeGUID", objectTypeGUID) :
                new ObjectParameter("ObjectTypeGUID", typeof(string));
    
            var objectNameParameter = objectName != null ?
                new ObjectParameter("ObjectName", objectName) :
                new ObjectParameter("ObjectName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_EditObjectType", objectTypeGUIDParameter, objectNameParameter, responseMessage);
        }
    
        public virtual int usp_EditRoomDetails(string roomGUID, string roomName, ObjectParameter responseMessage)
        {
            var roomGUIDParameter = roomGUID != null ?
                new ObjectParameter("RoomGUID", roomGUID) :
                new ObjectParameter("RoomGUID", typeof(string));
    
            var roomNameParameter = roomName != null ?
                new ObjectParameter("RoomName", roomName) :
                new ObjectParameter("RoomName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_EditRoomDetails", roomGUIDParameter, roomNameParameter, responseMessage);
        }
    
        public virtual int usp_EditRoomsHouse(string roomGUID, string houseGUID, ObjectParameter responseMessage)
        {
            var roomGUIDParameter = roomGUID != null ?
                new ObjectParameter("RoomGUID", roomGUID) :
                new ObjectParameter("RoomGUID", typeof(string));
    
            var houseGUIDParameter = houseGUID != null ?
                new ObjectParameter("HouseGUID", houseGUID) :
                new ObjectParameter("HouseGUID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_EditRoomsHouse", roomGUIDParameter, houseGUIDParameter, responseMessage);
        }
    
        public virtual int usp_EditUserDetails(string userGUID, string userName, string firstName, string lastName, string emailAddress, ObjectParameter responseMessage)
        {
            var userGUIDParameter = userGUID != null ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_EditUserDetails", userGUIDParameter, userNameParameter, firstNameParameter, lastNameParameter, emailAddressParameter, responseMessage);
        }
    
        public virtual int usp_EditUserPassword(string userGUID, string userPassword, ObjectParameter responseMessage)
        {
            var userGUIDParameter = userGUID != null ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(string));
    
            var userPasswordParameter = userPassword != null ?
                new ObjectParameter("UserPassword", userPassword) :
                new ObjectParameter("UserPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_EditUserPassword", userGUIDParameter, userPasswordParameter, responseMessage);
        }
    
        public virtual int usp_RemoveOwnerFromHouse(string userGUID, string houseGUID, ObjectParameter responseMessage)
        {
            var userGUIDParameter = userGUID != null ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(string));
    
            var houseGUIDParameter = houseGUID != null ?
                new ObjectParameter("HouseGUID", houseGUID) :
                new ObjectParameter("HouseGUID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_RemoveOwnerFromHouse", userGUIDParameter, houseGUIDParameter, responseMessage);
        }
    
        public virtual int usp_RemoveOwnerFromRoom(string userGUID, string roomGUID, ObjectParameter responseMessage)
        {
            var userGUIDParameter = userGUID != null ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(string));
    
            var roomGUIDParameter = roomGUID != null ?
                new ObjectParameter("RoomGUID", roomGUID) :
                new ObjectParameter("RoomGUID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_RemoveOwnerFromRoom", userGUIDParameter, roomGUIDParameter, responseMessage);
        }
    
        public virtual int usp_UserLogin(string userName, string userPassword, ObjectParameter responseMessage, ObjectParameter userGuid)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userPasswordParameter = userPassword != null ?
                new ObjectParameter("UserPassword", userPassword) :
                new ObjectParameter("UserPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_UserLogin", userNameParameter, userPasswordParameter, responseMessage, userGuid);
        }
    
        public virtual int usp_VerifyEmailAddress(string userGUID, ObjectParameter responseMessage)
        {
            var userGUIDParameter = userGUID != null ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_VerifyEmailAddress", userGUIDParameter, responseMessage);
        }
    
        public virtual int usp_UserAdminHouse(string userGuid, string houseGuid, ObjectParameter permission)
        {
            var userGuidParameter = userGuid != null ?
                new ObjectParameter("UserGuid", userGuid) :
                new ObjectParameter("UserGuid", typeof(string));
    
            var houseGuidParameter = houseGuid != null ?
                new ObjectParameter("HouseGuid", houseGuid) :
                new ObjectParameter("HouseGuid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_UserAdminHouse", userGuidParameter, houseGuidParameter, permission);
        }
    
        public virtual int usp_AddTypeToObject(string objectGUID, string objectTypeGUID, ObjectParameter responseMessage)
        {
            var objectGUIDParameter = objectGUID != null ?
                new ObjectParameter("ObjectGUID", objectGUID) :
                new ObjectParameter("ObjectGUID", typeof(string));
    
            var objectTypeGUIDParameter = objectTypeGUID != null ?
                new ObjectParameter("ObjectTypeGUID", objectTypeGUID) :
                new ObjectParameter("ObjectTypeGUID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddTypeToObject", objectGUIDParameter, objectTypeGUIDParameter, responseMessage);
        }
    }
}
