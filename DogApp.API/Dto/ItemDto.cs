﻿namespace DogApp.API.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsSign { get; set; }
        public string? Category { get; set; }
        public ICollection<TrackItem> TrackItems { get; set; }

        public ItemDto(int id, string? name, string? description, string? image)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
        }
        public ItemDto(int id, string? name)
        {

        }

        public ItemDto()
        {
        }
    }
}