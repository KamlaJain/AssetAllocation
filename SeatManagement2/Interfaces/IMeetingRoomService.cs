using System.Collections.Generic;
using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IMeetingRoomService
    {
        List<MeetingRoom> GetAllMeetingRooms();
        void AddMeetingRoom(MeetingRoomDTO meetingRoomDTO);
        void DeleteMeetingRoom(int meetingRoomId);
    }
}
