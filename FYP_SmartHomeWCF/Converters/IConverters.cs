using FYP_SmartHomeWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Converters
{
    public class IConverters
    {
        public User ConvertToUserModel(tblUser tbluser)
        {
            var user = new User();

            user.UserGuid = tbluser.UserGUID;
            user.EmailAddress = tbluser.EmailAddress;
            user.EmailVerified = Convert.ToBoolean(tbluser.EmailVerified);
            user.FirstName = tbluser.FirstName;
            user.LastName = tbluser.LastName;
            user.UserName = tbluser.UserName;

            return user;
        }

        public UserHomes ConvertToUserHomesModel(IQueryable<tblHouseOwner> tblhouseowner, Guid userGuid)
        {
            var userHomes = new UserHomes();
            userHomes.userGuid = userGuid;
            userHomes.homes = new List<House>();
            //userHomes.homes
            foreach (var home in tblhouseowner)
            {
                //House house = new House();
                //house.HouseGuid = (home.HouseGUID.HasValue)?home.HouseGUID.Value:Guid.Empty;
                //house.HouseName = home.tblHouse.HouseName;
                userHomes.homes.Add(ConvertToHouse(home.tblHouse));
            }

            return userHomes;
        }

        public House ConvertToHouse(tblHouse home)
        {
            House house = new House();
            house.HouseGuid = home.HouseGUID;
            house.HouseName = home.HouseName;
            return house;
        }

        public UserRooms ConvertToUserRoomsModel(IQueryable<tblRoomOwner> tblroomowner, Guid userGuid)
        {
            var userRooms = new UserRooms();
            userRooms.userGuid = userGuid;
            userRooms.rooms = new List<Room>();
            //userHomes.homes
            foreach (var rooms in tblroomowner)
            {
                Room room = new Room();
                room.RoomGuid = (rooms.RoomGUID.HasValue) ? rooms.RoomGUID.Value : Guid.Empty;
                room.HouseGuid = (rooms.tblRoom.HouseGUID.HasValue) ? rooms.tblRoom.HouseGUID.Value : Guid.Empty;
                room.RoomName = rooms.tblRoom.RoomName;
                userRooms.rooms.Add(room);
            }

            return userRooms;
        }

        public HouseRoomsWithPermission ConvertToHomeRoomsWithUserModel(IQueryable<tblRoom> tblroom, Guid houseGuid, Guid userGuid)
        {
            var houseRooms = new HouseRoomsWithPermission();
            houseRooms.house = houseGuid;
            houseRooms.roomsPermission = new List<KeyValuePair<bool, Room>>();
            //userHomes.homes
            foreach (var rooms in tblroom)
            {
                Room room = new Room();
                room.RoomGuid = rooms.RoomGUID;
                room.HouseGuid = (rooms.HouseGUID.HasValue) ? rooms.HouseGUID.Value : Guid.Empty;
                room.RoomName = rooms.RoomName;
                bool permission = rooms.tblRoomOwners.Any(x => x.UserGUID == userGuid);
                var newRoom = new KeyValuePair<bool, Room>(permission, room);
                houseRooms.roomsPermission.Add(newRoom);
            }

            return houseRooms;
        }

        public HouseRooms ConvertToHomeModel(IQueryable<tblRoom> tblroom, tblHouse home)
        {
            var houseRooms = new HouseRooms();
            houseRooms.house = ConvertToHouse(home);
            houseRooms.rooms = new List<Room>();

            foreach (var rooms in tblroom)
            {
                Room room = new Room();
                room.RoomGuid = rooms.RoomGUID;
                room.HouseGuid = (rooms.HouseGUID.HasValue) ? rooms.HouseGUID.Value : Guid.Empty;
                room.RoomName = rooms.RoomName;
                houseRooms.rooms.Add(room);
            }

            return houseRooms;
        }

        public List<Models.Object> ConvertToObjectModel(IQueryable<tblRoomObject> tblroomObject)
        {
            var objects = new List<Models.Object>();
            foreach (var obj in tblroomObject)
            {
                var o = ConvertEachObjectModel(obj);
                objects.Add(o);
            }
            return objects;
        }

        public Models.Object ConvertEachObjectModel(tblRoomObject obj)
        {

            var o = new Models.Object();
            o.ObjectDescription = obj.ObjectDescription;
            o.ObjectGuid = obj.ObjectGUID;
            o.ObjectState = obj.ObjectState;
            o.ObjectType = (obj.tblObjectType != null) ? obj.tblObjectType.ObjectName : null;
            o.ObjectTypeGuid = (obj.tblObjectType != null) ? obj.tblObjectType.ObjectTypeGUID: Guid.Empty;
            o.RoomGuid = (obj.tblRoom != null) ? obj.tblRoom.RoomGUID : Guid.Empty;
            o.HouseGuid = (obj.HouseGUID.HasValue) ? obj.HouseGUID.Value : Guid.Empty;
            return o;
        }
    }
}