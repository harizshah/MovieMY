// 👇 Namespace groups related classes under one logical name (like a folder in code)
namespace MovieAPI.Entities
{
    // 👇 'public' means this class can be accessed from anywhere in the project
    public class Genre
    {
        // 👇 Property #1: 'Id' is an integer (int)
        // It uniquely identifies each Genre record (e.g. 1 = Action, 2 = Comedy)
        public int Id { get; set; }

        // 👇 Property #2: 'Name' is a string (text)
        // 'required' means it MUST have a value (C# 11+ feature)
        // get; set; means you can read and modify this property
        public required string Name { get; set; }
    }
}