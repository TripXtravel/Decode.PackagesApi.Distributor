﻿namespace Decode.PackagesApi.Distributor.Common.Models
{
    internal class AccomodationResponse
    {
        public string Id { get; set; }
        public string ReferenceToken { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

    }
    public class Room
    {
        public int Adults { get; set; }
        public string Type { get; set; }
        public List<int> TravellerIds { get; set; } = new List<int>();
        public string SupplierRoomName { get; set; }
        public string OriginalRoomName { get; set; }
    }

    public class AvailableOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Board> Boards { get; set; }
    }

    public class Board
    {
        public string ProductToken { get; set; }
        public string BoardCode { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
    }
}
